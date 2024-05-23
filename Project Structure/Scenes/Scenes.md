![enter image description here](https://media.discordapp.net/attachments/916248167941566534/1242990960766484664/image.png?ex=664fd90a&is=664e878a&hm=f1255fcc613992ddf8840151b180ad8ce1cb510e85f691fff4b59cf825e1b56e&=&format=webp&quality=lossless)

***Scene은 총 3개로 구성 되어 있습니다.***

-  **StartGame** : 처음 게임을 시작하면 나오는 Scene입니다. 캐릭터를 선택할 수 있고 StageScene으로 전환할 수 있습니다.

-  **StageScene** : 총 4개의 Stage가 구성 되어있고 , StartGameScene으로 돌아갈 수 있는 기능과 Inventory를 확인할 수 있는 기능이 있고 , GameScene으로 전환할 수 있습니다.

- **GameScene** : 게임을 플레이 하는 Scene입니다. Player 오브젝트로 Vegetable 오브젝트를 피하는 게임이며 , 두 오브젝트가 충돌하면 Retry 버튼과 StageScene으로 돌아갈 수 있는 버튼이 있습니다.
또 게임 플레이에 도움이 되는 Item이 있고,
게임에 소리 조절, 재시작, StageScene으로 돌아가기 , 캐릭터 재선택 등을 할 수 있는 환경설정 기능이 있습니다.
게임 Stage를 클리어하면 Item을 랜덤으로 획득할 수 있습니다.
