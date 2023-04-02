# Dungeon-game-with-unity
The project used unity to create a simple 2d dungeon game

Demo
========================================================
unity版本： Windows 64位 2021.3.20f1c1

1.项目介绍
========================================================
主要负责游戏中的地图生成和游戏玩家的移动，还包括了一些玩家进出房间的判断。

在Assets中包括了使用的所有素材，其中Scripts中存放的为所有的控制脚本。

项目中主要运用了RoomGenerator方法，复制外观相似的房间，其中使用了算法实现
各个房间不重复及给定一定房间数量，房间在生成时不会与之前生成的房间重叠。

Prefabs中存放的是我们的样本房间，也就是被复制的房间，对其的修改会影响所有
生成的房间。

Wall为房间的外墙，设计外墙是为了防止房间之间相互能够隔绝，玩家能够在一个房间
在有更好的游戏体验。

2.开发方向
==========================================================
在prefabs中我添加了一个白色圆形组件key，这是为了与小组其他成员所编写的任务衔接，
但仍无完成时，key会出现。人物触碰到key后，四个门的属性会改变（解锁门）。

3.遇到的问题
==========================================================
人物与门的碰撞存在问题，由于每两个链接房间都存门，这导致人物在碰撞箱体和触发器之间
难以做到平衡。（你可以通过触发器穿越第一个房间的门，但是你不能改变第二个房间的箱体属性）
这就导致了人物在移动过程中受阻。

初步的解决方法：讲门的箱体都先设置为 非（is tigger），及人物无法透过门会被阻挡。在完成任务后
箱体变为（is tigger），人物可以穿过并触发触发器。在人物碰到room的触发器时，伴随着镜头的移动，
人物的坐标发生变化，进入到下一个房间的中心。


