# shadowverse-auto-quest

<h4>实现自动周回影之诗（国际服）的特殊quest与特殊questd电脑卡组修改</h4>
<h4>如果之后有特殊quest，此项目依旧会进行更新</h4>

## 原理

<h4>通过改电脑的卡组为40张世界树的衍生物：万象の加護，与卡片优先级，从而做到电脑第一回合自杀完成周回</h4>
<h4>软件原理为根据窗口的大小获得按键的XY坐标进行模拟点击</h4>

### 操作

* 直接将UnityEX里改好的两个后缀为Unlity文件放入影之诗数据目录的a目录里（如C:\Users\AppData\LocalLow\Cygames\Shadowverse\a）<br />
- 开游戏，选项里调整影之诗的解析度（分辨率）为1360X768<br />
* 开程序，输入循环次数，检测窗体（程序）<br />
- quest界面选臭鼬，在决定是否留卡的界面点击“执行”按钮<br />
* 挂机至完成便可（暂停快捷键为ALT+S）<br />
### 暂时无法解决的

以下均因为能力有限暂时无法完成<br />
* 后台进行模拟点击操作(如果是用按键精灵写可以完成）<br />
- 当程序在后台时，点击“执行”按钮有几率会出现鼠标在左上角的bug<br />
* 不能彻底的暂停（不妨碍使用，指代码优化问题，因不知道如何在线程过程中突然暂停，所以每一步都添加了检测）<br />

## 自己修改卡组

* 打开UnityEX（文件也在UnityEX文件夹里）<br />
- 找到要修改的卡组文件（依旧在上述的a文件夹中）名称为master_ai_deck_quest_boss名.unity3d（例如master_ai_deck_quest_karyl.unity3d，这是臭鼬的）<br />
* 用UnityEX打开要修改的文件（`一定要先备份`），对拆出来的txt右键Export输出，此时在打开的那个文件的根目录会生成一个Unity_Assets_Files文件夹，进去用记事本等工具打开修改就好了<br />
- 修改完后Import files封包回去就好了<br />
## 注意事项

<h4>一定要先备份<br /> 一定要先备份 <br />一定要先备份<br /></h4>
<h4>修改完后的字节一定要跟之前一样（即EX里第三列显示的size大小）</h4>

***

## 参考

 [ UnityEX的原作者](https://www.undertow.club/threads/mod-shadowverse-for-pc-on-steam.9976/)<br />
 [ C#中鼠标的移动点击](https://blog.csdn.net/TH_NUM/article/details/83274835)
