using UnityEngine;

public class SendRequest : MonoBehaviour
{
    public void OnSendRequestButtonClicked()
    {
        Debug.Log("Send Request button clicked.");
        // ここにリクエスト送信処理を追加

        Order order = new Order();
        order.CreateOrder(101, 2);
    }

    public void OnGetOrderButtonClicked()
    {
        Debug.Log("Get Order button clicked.");
        // ここに注文取得処理を追加

        Order order = new Order();
        order.GetOrder(1);
    }
}
