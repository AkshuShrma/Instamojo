using InstamojoAPI;
using Nancy;
using Nancy.Session;

namespace PaymentInstamojo.models
{
    public class InstamojoService
    {
        private readonly string clientId;
        private readonly string clientSecret;
        public InstamojoService(string clientId, string clientSecret)
        {
            this.clientId = clientId;
            this.clientSecret = clientSecret;
        }
        public async Task<string> CreatePaymentRequest(OrderRequest request)
        {
            string apiKey = InstamojoConstants.INSTAMOJO_API_ENDPOINT,
                authToken = InstamojoConstants.INSTAMOJO_AUTH_ENDPOINT;
            Instamojo api = InstamojoImplementation.getApi(clientId,clientSecret,apiKey,authToken);

            PaymentOrder order = new PaymentOrder();
            order.name = request.Name;
            order.email = request.Email;
            order.phone = request.Phone;
            order.amount = request.Ammount;
            order.currency = "INR";
            order.description = "Welcome to instamojo";
            order.redirect_url = "http://localhost:3000";

            string randomNumber = Path.GetRandomFileName();
            randomNumber = randomNumber.Replace(".", string.Empty);
            order.transaction_id = "test" + randomNumber;

            //Session["transId"] = order.transaction_id;
            //CreatePaymentOrder(api);

            CreatePaymentOrderResponse createPaymentResponse = api.createNewPaymentRequest(order);

            // Payment request created successfully
            string paymentUrl = createPaymentResponse.payment_options.payment_url;
            return paymentUrl;
        }
/*
        private void CreatePaymentOrder(OrderRequest api)
        {
            PaymentOrder order = new PaymentOrder();
            order.name = api.Name;
            order.email = api.Email;
            order.phone = api.Phone;
            order.amount = api.Ammount;
            order.currency = api.Curruncy;
            order.description = "This is ak";
            order.transaction_id = api.TransectionId;
        }*/
    }
}
