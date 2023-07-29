# SimpleLauncher

跨平台，可拓展，支持TUI，能包装的命令行Minecraft启动器

## 目录

- [安装](#安装)
- [使用说明](#使用说明)
	- [生成器](#生成器)
- [徽章](#徽章)
- [示例](#示例)
- [相关仓库](#相关仓库)
- [维护者](#维护者)
- [如何贡献](#如何贡献)
- [使用许可](#使用许可)

## 安装

您可以在本项目Github页面的右侧找到Release并下载对应的版本。  
针对不同平台的安装将在后续的版本中陆续支持。

## 使用说明

Tips: 使用前确保您的系统中有 `.NET Core 7.0` 的环境

通过如下的使用可以让启动器在命令行界面中直接调用
```sh
$ dotnet slr.dll [args]
```
通过如下的使用可以直接启动启动器自带的Console
```sh
$ dotnet slr.dll
```

## 相关仓库

- [SLCore](https://github.com/PowerAngelXD/SLCore) — 作者开发的适配于SimpleLauncher的核心库，主要包含命令定义，异常处理等功能，通过这个库用户可以自行开发想要的插件

## 维护者

[@PowerAngelXD](https://github.com/PowerAngelXD)

### 贡献者

感谢以下参与项目的人：  
[@yueyinqiu](https://github.com/yueyinqiu)


## 使用许可

[MIT](LICENSE) © PowerAngelXD
