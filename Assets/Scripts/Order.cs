using System;
using Cysharp.Net.Http;
using Grpc.Net.Client;
using grpc_orders.Scripts.Generated;
using UnityEngine;

public class Order
{
    // gRPCサーバーのアドレス (Cloud RunでデプロイしたサーバーのURL)
    private const string ServerAddress = "https://localhost:9000";

    private readonly OrderService.OrderServiceClient _client;

    public Order()
    {
        // YetAnotherHttpHandlerを使用して、HTTP/2対応のカスタムハンドラを作成
        var httpHandler = new YetAnotherHttpHandler();
        httpHandler.SkipCertificateVerification = true; // 開発環境で自己署名証明書を使用する場合に必要

        var channel = GrpcChannel.ForAddress(ServerAddress, new GrpcChannelOptions
        {
            HttpHandler = httpHandler
        });

        _client = new OrderService.OrderServiceClient(channel);
    }


    public async void CreateOrder(int productId, int quantity)
    {
        var request = new CreateOrderRequest
        {
            CustomerId = 1,
            ProductId = productId,
            Quantity = quantity,
        };

        try
        {
            await _client.CreateOrderAsync(request);
            Debug.Log("Order created successfully!");
        }
        catch (Exception e)
        {
            Debug.LogError($"gRPC Error: {e.Message}");
        }
    }

    public async void GetOrder(int customerId)
    {
        var request = new GetOrderRequest
        {
            CustomerId = customerId,
        };

        try
        {
            var response = await _client.GetOrdersAsync(request);
            var orders = response.Orders;
            foreach (var order in orders)
            {
                Debug.Log($"Order Id={order.CustomerId}, ProductId={order.ProductId}, Quantity={order.Quantity}");
            }
        }
        catch (Exception e)
        {
            Debug.LogError($"gRPC Error: {e.Message}");
        }
    }

}
