// Strategy: PaymentStrategy interface
public interface IPaymentStrategy
{
    string Name { get; } // New property to check match by name
    void ProcessPayment(float amount);
}

// Context: BankTransaction class
public class BankTransaction
{
    private IPaymentStrategy paymentStrategy;

    public void SetPaymentStrategy(IPaymentStrategy strategy)
    {
        paymentStrategy = strategy;
    }

    public void ExecuteTransaction(float amount)
    {
        if (paymentStrategy == null)
        {
            Console.WriteLine("Please set a payment strategy before executing a transaction.");
            return;
        }

        Console.WriteLine($"Executing a transaction with {paymentStrategy.Name} strategy:");
        paymentStrategy.ProcessPayment(amount);
    }
}

// ConcreteStrategy1: DebitCardPayment
public class DebitCardPayment : IPaymentStrategy
{
    public string Name => "DebitCard"; // New property

    public void ProcessPayment(float amount)
    {
        Console.WriteLine($"Paying {amount} using Debit Card.");
    }
}

// ConcreteStrategy2: CreditCardPayment
public class CreditCardPayment : IPaymentStrategy
{
    public string Name => "CreditCard"; // New property

    public void ProcessPayment(float amount)
    {
        Console.WriteLine($"Paying {amount} using Credit Card.");
    }
}

// ConcreteStrategy3: TransferPayment
public class TransferPayment : IPaymentStrategy
{
    public string Name => "Transfer"; // New property

    public void ProcessPayment(float amount)
    {
        Console.WriteLine($"Transferring {amount} to another account.");
    }
}

class Program
{
    static void Main()
    {
        BankTransaction transaction = new BankTransaction();

        // Get list of payment strategies
        IEnumerable<IPaymentStrategy> paymentStrategies = GetPaymentStrategies();

        // Choose a payment strategy based on name
        string selectedPaymentStrategyName = "CreditCard"; // Replace with desired strategy name
        IPaymentStrategy selectedPaymentStrategy = paymentStrategies.First(x => x.Name.Equals(selectedPaymentStrategyName));

        // Set the selected payment strategy
        transaction.SetPaymentStrategy(selectedPaymentStrategy);

        // Execute a transaction
        transaction.ExecuteTransaction(150.00f);
    }

    static IEnumerable<IPaymentStrategy> GetPaymentStrategies()
    {
        return new List<IPaymentStrategy>
        {
            new DebitCardPayment(),
            new CreditCardPayment(),
            new TransferPayment()
        };
    }
}
