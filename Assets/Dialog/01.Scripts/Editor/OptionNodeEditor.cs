
//#if UNITY_EDITOR
//using UnityEditor;
//using UnityEngine;
//using UnityEditorInternal;

//namespace Dialog
//{
//    [CustomEditor(typeof(OptionNodeSO))]
//    public class OptionNodeEditor : Editor
//    {
//        private OptionNodeSO _optionSO;
//        public SerializedProperty _animationGroup;
//        public SerializedProperty _optionPrefab;
//        public SerializedProperty _options;
//        private GUIStyle _textAreaStyle;
//        public ReorderableList optionList;


//        private int _selected = -1;
//        private bool _isOptionOpen = false;

//        private void OnEnable()
//        {
//            StyleSetup();
//            _optionSO = (OptionNodeSO)target;

//            optionList = new ReorderableList(
//                serializedObject,
//                serializedObject.FindProperty("options"),
//                true, true, true, true);
//            _animationGroup = serializedObject.FindProperty("animationGroup");
//            _optionPrefab = serializedObject.FindProperty("optionPrefab");
//            _options = serializedObject.FindProperty("options");

//            //15 + 5 + 70 + 5 + 15 + 5
//            optionList.elementHeight = 115;
//            optionList.drawElementCallback = (rect, index, active, focused) =>
//            {
//                StyleSetup();

//                var element = optionList.serializedProperty.GetArrayElementAtIndex(index);
//                var optionProp = element.FindPropertyRelative("option");

//                Rect labelRect = new Rect(rect.x, rect.y, rect.width, 15);
//                Rect txtAreaRect = new Rect(rect.x, rect.y + 20, rect.width, 70);
//                Rect nextNodeRect = new Rect(rect.x, rect.y + 95, rect.width, 15);

//                EditorGUI.LabelField(labelRect, $"Option-{index}");
//                optionProp.stringValue = EditorGUI.TextArea(txtAreaRect, optionProp.stringValue, _textAreaStyle);
//            };

//            optionList.drawHeaderCallback = rect => EditorGUI.LabelField(rect, "Options");
//            optionList.onAddCallback = list => _optionSO.AddOption();
//            optionList.onRemoveCallback = list =>
//            {
//                if (_optionSO.options.Count >= 0)
//                {
//                    //���õȰ� ������
//                    if (list.index == -1)
//                    {
//                        //���� �ڿ��ִ°Ÿ� ������
//                        _optionSO.RemoveOption(_optionSO.options.Count - 1);
//                    }
//                    else
//                    {
//                        //���õȰŸ� ������
//                        _optionSO.RemoveOption(list.index);
//                    }
//                }
//            };
//        }

//        public override void OnInspectorGUI()
//        {
//            serializedObject.Update();
//            EditorGUILayout.PropertyField(_animationGroup);
//            optionList.DoLayoutList();
//            EditorGUILayout.PropertyField(_optionPrefab);
//            serializedObject.ApplyModifiedProperties();

//            if (GUILayout.Button("SetAsFirstNode"))
//            {
//                _optionSO.OnSetAsFirstNode?.Invoke(_optionSO);
//            }
//        }

//        private void StyleSetup()
//        {
//            if (_textAreaStyle == null)
//            {
//                _textAreaStyle = new GUIStyle(EditorStyles.textArea);
//                _textAreaStyle.wordWrap = true;
//            }
//        }
//    }
//}

//#endif