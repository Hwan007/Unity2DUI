# Unity2DUI by 채이환
#### 선택과제

"스파르타 던전 - Unity  버전!"을 조금 변형 시켜봤습니다.

빌드 버전 : https://github.com/Hwan007/Unity2DUI/releases/tag/0.0.1

#### 구현 기능

1. 스테이터스 표시
- 장착 아이템 스탯 적용
2. 인벤토리 표시
- 장착 아이템 표시
- 소지 아이템 표시
3. Esc, Q를 누를 경우에 UI 닫기

#### 주요 사항

1. UIObjectPool로 일부 UI 게임 오브젝트를 공유
2. event로 장비 장착/탈착 시에 스탯 계산하도록 구성
3. 버튼과 중앙 플래이어를 제외하고는 자동적으로 생성하도록 구성

#### 아쉬운 점

1. 버튼은 사라지지 않습니다. 버튼까지 Object Pool로 자동 생성하도록 하고 싶었으나, 시간이 부족하였습니다.
2. 필요없는 부분(InventyroEvnet, EquipEvnet에서)까지 event를 사용하여 코드가 복잡해졌습니다.
3. 인벤토리 아이템은 스크롤뷰이고 미리 전부 생성하게 되어 있습니다. 다음에 무한스크롤을 적용하여 보고 싶습니다.

#### 시연 영상
https://github.com/Hwan007/Unity2DUI/assets/96556920/0029ff76-3285-492b-8aa0-eb74c75bfaa0
