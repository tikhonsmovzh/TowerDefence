using AirFishLab.ScrollingList;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class BuildControl : MonoBehaviour, IPointerDownHandler
{
    private List<Building> _buildedPanel = new ();

    [SerializeField] private Building _selectedBuilding;
    [SerializeField] private string _greenTag;
    [SerializeField] private float _buildStep;
    [SerializeField] private CastleHpView _hpView;
    public void AddBuildingsToPanel(IEnumerable<Building> buildings)
    {
        _buildedPanel.AddRange(buildings);
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        var vec = Camera.main.ScreenToWorldPoint(eventData.position);
        vec.z = 0;

        bool isGreen(List<Collider2D> coliders)
        {
            var filterRes = coliders.Where(i => i.tag == _greenTag).ToList();

            return filterRes.Count == coliders.Count && filterRes.Count == 1;
        }

        var res = new List<Collider2D>();
        Physics2D.OverlapBox(vec, _selectedBuilding.size, 0, new ContactFilter2D().NoFilter(), res);

        if (!isGreen(res))
            return;

        var halfSize = _selectedBuilding.size / 2;

        Physics2D.OverlapPoint(new Vector2(vec.x + halfSize.x, vec.y + halfSize.y), new ContactFilter2D().NoFilter(), res);

        if (!isGreen(res))
            return;

        Physics2D.OverlapPoint(new Vector2(vec.x + halfSize.x, vec.y - halfSize.y), new ContactFilter2D().NoFilter(), res);

        if (!isGreen(res))
            return;

        Physics2D.OverlapPoint(new Vector2(vec.x - halfSize.x, vec.y + halfSize.y), new ContactFilter2D().NoFilter(), res);

        if (!isGreen(res))
            return;

        Physics2D.OverlapPoint(new Vector2(vec.x - halfSize.x, vec.y - halfSize.y), new ContactFilter2D().NoFilter(), res);

        if (!isGreen(res))
            return;

        if (_hpView.GetGold() < _selectedBuilding.CostGold) // так сделано, потому что, по неизвестным причинам 
            return; // && не работает и серебро уходит в минус. . .

        if (_hpView.GetSilver() < _selectedBuilding.CostSilver)
            return;

        Instantiate(_selectedBuilding.WorldObject, vec, Quaternion.identity);
        _hpView.SetGold(-_selectedBuilding.CostGold);
        _hpView.SetSilver(-_selectedBuilding.CostSilver);
    }
}
