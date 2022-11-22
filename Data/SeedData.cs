namespace epitec.Data;

public static class SeedData
{
    public static void Initialize(ContactStoreContext db)
    {
        var contacts = new Contact[]
        {
            // new Contact()
            // {
            //     Id = 1,
            //     FirstName = "John",
            //     LastName = "Smith",
            //     PhoneNumber = "1111111111",
            //     BirthDate = new DateTime(1990, 1, 1)
            // },
            // new Contact()
            // {
            //     Id = 2,
            //     FirstName = "Jane",
            //     LastName = "Doe",
            //     PhoneNumber = "2222222222",
            //     BirthDate = new DateTime(1990, 1, 1)
            // },
            // new Contact()
            // {
            //     Id = 3,
            //     FirstName = "John",
            //     LastName = "Doe",
            //     PhoneNumber = "3333333333",
            //     BirthDate = new DateTime(1990, 1, 1)
            // },
            // new Contact()
            // {
            //     Id = 4,
            //     FirstName = "Jane",
            //     LastName = "Smith",
            //     PhoneNumber = "4444444444",
            //     BirthDate = new DateTime(1990, 1, 1)
            // },
            // new Contact()
            // {
            //     Id = 5,
            //     FirstName = "John",
            //     LastName = "Apple",
            //     PhoneNumber = "5555555555",
            //     BirthDate = new DateTime(1990, 1, 1)
            // },
        };
        db.Contacts.AddRange(contacts);
        db.SaveChanges();
    }
}