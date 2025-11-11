## setup

https://github.com/GlitchEnzo/NuGetForUnity
上記からunity用のnugetを導入

https://github.com/Cysharp/YetAnotherHttpHandler?tab=readme-ov-file#installation
UnityでHTTP/2に必要なので上記を導入

### nugetから導入

* Google.Protobuf
* Grpc.Tools
  * pluginが必要なので入れる
* Grpc.Net.Client
* System.IO.Pipelines

### YetAnotherHttpHandlerの導入
* UPMにてgitURLで追加から追加
https://github.com/Cysharp/YetAnotherHttpHandler.git?path=src/YetAnotherHttpHandler#1.11.3


## protobufでスクリプト生成
* [Makefile](./Makefile)を参照

