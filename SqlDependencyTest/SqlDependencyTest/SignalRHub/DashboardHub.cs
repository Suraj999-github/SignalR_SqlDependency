using Microsoft.AspNetCore.SignalR;

namespace SqlDependencyTest.SignalRHub
{
    public class DashboardHub : Hub
    {      
        public async Task SendProducts()
        {
            try
            {               
                var products = "test sql dependency";
                await Clients.All.SendAsync("ReceivedProducts", products);
            }
            catch (Exception ex)
            {
                var msg=ex.Message;
            }         
        }
    }
}
