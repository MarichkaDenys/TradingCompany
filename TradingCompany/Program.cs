using AutoMapper;
using DAL;
using DAL.Concreate;

var connectionString = "Data Source=DESKTOP-CGN0J7I\\MSSQLSERVER01;Initial Catalog=Trading Company;Integrated Security=True;TrustServerCertificate=True;Encrypt=False";
var mapper = SetupMapper();

while (true)
{
    Console.WriteLine("Type command: \n\t1 Add product: \n\t2 List products: \n\t3 Delete product: \n\t4 Update product: \n\t5 Add category: \n\t6 Delete category: \n\t0 Quit: \n");
    char c = char.Parse(Console.ReadLine());
    switch (c)
    {
        case '1': AddProduct(connectionString, mapper); break;
        case '2': ListProducts(connectionString, mapper); break;
        case '3': DeleteProduct(connectionString, mapper); break;
        case '4': UpdateProduct(connectionString, mapper); break;
        case '5': AddCategory(connectionString, mapper); break;
        case '6': DeleteCategory(connectionString, mapper); break;


        case '0': Quit(); return;
        default:
            Console.WriteLine("Invalid command. Please try again.");
            break;
    }
    Console.WriteLine();
}

void DeleteCategory(string connectionString, IMapper mapper)
{
    Console.Write("Enter Category ID to delete: ");
    int categoryId = Convert.ToInt32(Console.ReadLine());

    using (var dal = new CategoryDal(connectionString, mapper))
    {
        dal.DeleteById(categoryId);
        Console.WriteLine("Category deleted successfully.");
    }
}

void AddCategory(string connectionString, IMapper mapper)
{
    Console.Write("Category Name: ");
    string categoryName = Console.ReadLine();

    using (var dal = new CategoryDal(connectionString, mapper))
    {
        var newEntity = dal.Insert(new Category
        {
            CategoryName = categoryName,
            Date = DateTime.Now
        });
        Console.WriteLine($"New category ID: {newEntity.CategoryId}");
    }
}

void UpdateProduct(string connectionString, IMapper mapper)
{
    Console.Write("Enter Product ID to update: ");
    int productId = Convert.ToInt32(Console.ReadLine());

    using (var dal = new ProductDal(connectionString, mapper))
    {
        var existingProduct = dal.GetById(productId);

        if (existingProduct != null)
        {
            Console.Write("Product Name: ");
            existingProduct.ProductName = Console.ReadLine();
            Console.Write("Quantity: ");
            existingProduct.Quantity = Convert.ToInt32(Console.ReadLine());
            Console.Write("Unit Price: ");
            existingProduct.UnitPrice = Convert.ToInt32(Console.ReadLine());
            existingProduct.Date = DateTime.Now;
            dal.Update(existingProduct);
            Console.WriteLine("Product updated successfully.");
        }

        else
        {
            Console.WriteLine($"Product with ID {productId} not found.");
        }
    }
}

void DeleteProduct(string connectionString, IMapper mapper)
{
    Console.Write("Enter Product ID to delete: ");
    int productId = Convert.ToInt32(Console.ReadLine());

    using (var dal = new ProductDal(connectionString, mapper))
    {
        dal.DeleteById(productId);
        Console.WriteLine("Product deleted successfully.");
    }
}

void ListProducts(string connectionString, IMapper mapper)
{
    using (var dal = new ProductDal(connectionString, mapper))
    {
        List<Product> products = dal.GetAll();

        foreach (Product p in products)
        {
            Console.WriteLine($"{p.ProductId}\t{p.CategoryId}\t{p.ProductName}\t{p.Quantity}\t{p.UnitPrice}\t{p.Date}");
        }
    }
}

void AddProduct(string connectionString, IMapper mapper)
{
    Console.Write("Category ID: ");
    int categoryId = Convert.ToInt32(Console.ReadLine());

    Console.Write("Product Name: ");
    string productName = Console.ReadLine();

    Console.Write("Quantity: ");
    int quantity = Convert.ToInt32(Console.ReadLine());

    Console.Write("Unit Price: ");
    decimal unitPrice = Convert.ToDecimal(Console.ReadLine());

    using (var dal = new ProductDal(connectionString, mapper))
    {
        var newEntity = dal.Insert(new Product
        {
            ProductName = productName,
            Quantity = quantity,
            UnitPrice = (int)unitPrice,
            CategoryId = categoryId,
            Date = DateTime.Now
        });
        Console.WriteLine($"New product ID: {newEntity.ProductId}");
    }
}

IMapper SetupMapper()
{
    MapperConfiguration config = new MapperConfiguration(cfg => cfg.AddMaps(typeof(ProductDal).Assembly));
    return config.CreateMapper();
}



void Quit()
{
    Console.WriteLine("Bye!");
}
