using AdvancedLinqChallenge.Controller;
using AdvancedLinqChallenge.Service;
using AdvancedLinqChallenge.View;

namespace Assignments
{
    public class Program
    {
        public static void Main(string[] args)
        {
            ProductView view = new ProductView();
            ProductManager manager = new ProductManager();
            TaskController controller = new TaskController(manager, view);
            controller.RunApplication();
        }
    }
}