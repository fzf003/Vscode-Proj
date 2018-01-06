
set TOOLS_PATH=Grpc.Tools.1.8.0\tools\windows_x64

%TOOLS_PATH%\protoc.exe -I protos --csharp_out Service  protos/helloworld.proto --grpc_out Service --plugin=protoc-gen-grpc=%TOOLS_PATH%\grpc_csharp_plugin.exe

 