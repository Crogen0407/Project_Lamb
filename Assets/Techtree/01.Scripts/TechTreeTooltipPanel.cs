using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.UI;

namespace TechTree
{
    public class TechTreeTooltipPanel : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
    {
        private RectTransform _rectTrm;

        [SerializeField] private RectTransform _bgRTrm;
        [SerializeField] private Image _icon;
        [SerializeField] private TextMeshProUGUI _name, _explain;
        private bool _pointerEnter = false;

        private void Awake()
        {
            _rectTrm = GetComponent<RectTransform>();
        }

        private void Update()
        {
            if (Mouse.current.leftButton.wasPressedThisFrame && !_pointerEnter)
                Close();
        }

        public void Close()
        {
            gameObject.SetActive(false);
        }

        public void Open()
        {
            gameObject.SetActive(true);

            Vector2 mousePosition = Input.mousePosition;
            mousePosition.x = Mathf.Clamp(mousePosition.x, 0f, Screen.width - _bgRTrm.sizeDelta.x);
            mousePosition.y = Mathf.Clamp(mousePosition.y, _bgRTrm.sizeDelta.y, Screen.height);

            _rectTrm.anchoredPosition = mousePosition;
        }

        public void SetNodeInformation(NodeSO node)
        {
            if (node is StartNodeSO)
            {
                Close();
                return;
            }

            if (node is TestNodeSO test)
            {
                _icon.sprite = null;
                _name.SetText(test.nodeName);
                _explain.SetText(test.nodeExplain);
            }

            //if (node is PartNodeSO part)
            //{
            //    _icon.sprite = part.icon;
            //    _type.SetText("Part");
            //    _name.SetText(part.openPart.ToString());
            //    _explain.SetText(part.explain);
            //    _coin.SetText($"필요 코인: {part.requireCoin}");
            //}
            //else if (node is WeaponNodeSO weapon)
            //{
            //    _icon.sprite = weapon.icon;
            //    _type.SetText("Weapon");
            //    _name.SetText(weapon.weapon.ToString());
            //    _explain.SetText(weapon.explain);
            //    _coin.SetText($"필요 코인: {weapon.requireCoin}");
            //}
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            _pointerEnter = false;
        }
        public void OnPointerEnter(PointerEventData eventData)
        {
            _pointerEnter = true;
        }
    }
}
