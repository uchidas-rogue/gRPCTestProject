
GRPC_CSHARP_PLUGIN="Packages/Grpc.Tools.2.72.0/tools/macosx_x64/grpc_csharp_plugin"

gen:
	chmod +x $(GRPC_CSHARP_PLUGIN)
	mkdir -p Assets/Scripts/Genprotos/Orders
	@protoc -I="Protos" \
		--csharp_out=Assets/Scripts/Genprotos/Orders \
		--grpc_out=Assets/Scripts/Genprotos/Orders \
		--plugin=protoc-gen-grpc=$(GRPC_CSHARP_PLUGIN) \
		orders.proto
