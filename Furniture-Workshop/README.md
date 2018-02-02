<img src="https://i.imgur.com/yqIN5FX.png" width="300px" />

## Furniture Factory - workshop (OOP - Final)

The Furniture factory already has a working Engine. You do not have to touch anything in it. Just use it.

A furniture manufacturer keeps track of their companies and furniture: tables and chairs. 
- Each furniture piece has **model, material, price in dollars, and height in meters**. 
- Each table has **length and width in meters**. 
- Chairs are three types: **normal, adjustable and convertible**. 
  - Each chair has number of legs. 
  - Each adjustable chair can adjust its height. 
  - Each convertible chair can convert its state and be easily movable. 
- Each company has **name, registration number and catalog of furniture**. Companies can add or remove furniture to their catalogs. Companies can find furniture by model. Companies can show catalogs of all furniture they offer. 

### Design the Class Hierarchy
Your task is to design an object-oriented class hierarchy to model the Furniture Factory, using the best practices for object-oriented design (OOD) and object-oriented programming (OOP). Avoid duplicated code though abstraction, inheritance, and polymorphism and encapsulate correctly all fields.
You are given few C# interfaces that you should obligatory implement and use as a basis of your code:

```csharp
namespace FurnitureManufacturer.Interfaces
{
    public interface ICompany
    {
        string Name { get; }

        string RegistrationNumber { get; }

        ICollection<IFurniture> Furnitures { get; }

        void Add(IFurniture furniture);

        void Remove(IFurniture furniture);

        IFurniture Find(string model);

        string Catalog();
    }

    public interface IFurniture
    {
        string Model { get; }

        string Material { get; }

        decimal Price { get; set; }

        decimal Height { get; }
    }

    public interface IChair
    {
        int NumberOfLegs { get; }
    }

    public interface ITable
    {
        decimal Length { get; }

        decimal Width { get; }

        decimal Area { get; }
    }

    public interface IAdjustableChair
    {
        void SetHeight(decimal height);
    }

    public interface IConvertibleChair
    {
        bool IsConverted { get; }

        void Convert();
    }
}
```

- All your furniture should implement IFurniture. 
- Tables should implement ITable
- Chairs should implement IChair, adjustable chairs should implement IAdjustableChair and convertible chairs should implement IConvertibleChair. 
- Companies should implement ICompany.

### Validation
- Furniture
  - Model cannot be empty, null or with **less than 3 symbols**.
  - Price cannot be **less or equal to 0.00**.
  -	Height cannot be **less or equal to 0.00**.
- Table validity rules:
    - Can calculate area by the following formula: **length * width** (much wow).
    - Adjustable chair validity rules:
    - Can change the height to a new valid one. 
- Convertible chair validity rules:
    - Has too states – **converted and normal**.
    - States can be changed by converting the chair from one to another.
    - Converted state sets **the height to 0.10**.
    - Normal state returns **the height to the initial one**.
    - Initial state is **normal**.
- Company validity rules:
    - Name cannot be empty, null or **with less than 5 symbols**.
    - Registration number must be **exactly 10 symbols and must contain only digits**. 
    - Adding duplicate furniture is allowed.
    - Removing furniture removes **the first occurrence**. If such is not found, **nothing happens**.
    - Finding furniture by model gets **the first occurrence**. If such is not found, return null. **Searching is case insensitive**.
- Companies should only be created through the ICompanyFactory implemented by a class named CompanyFactory.
- Furniture should only be created through the IFurnitureFactory implemented by a class named
  - FurnitureFactory. Both classes are in the FurnitureManufacturer.Engine.Factories namespace.
- The company catalog method returns the information about the available furniture in the following form:

```
(company name) – (number of furniture/”no”) (“furniture”/”furnitures”)
(information about furniture)
(information about furniture)
(information about furniture)
```

- The listed furniture added to a certain company (through the Add(…) method) must be **ordered by price then by model**. 
  - If the company has no furniture added, print “no furnitures” (**yes, “furnitures” is not a valid word, these are the client's requirements**).
  - If the company has 1 piece of furniture, print “1 furniture” and show its information on a separate line. - If the company has more than 1 piece of furniture, print its number and list each one’s information on a separate line. 
  - All decimal type fields should be printed “as is”, without any formatting or rounding.


### Printing

- You may use the following for reference:

```
"{0} - {1} - {2} {3}",
this.Name,
this.RegistrationNumber,
this.Furnitures.Count != 0 ? this.Furnitures.Count.ToString() : "no",
this.Furnitures.Count != 1 ? "furnitures" : "furniture"
```

**Look into the example below to get better understanding of the printing format.**

- The table information should be in the following form:

```
"Type: {0}, Model: {1}, Material: {2}, Price: {3}, Height: {4}, Length: {5}, Width: {6}, Area: {7}", this.GetType().Name, this.Model, this.Material, this.Price, this.Height,  this.Length, this.Width, this.Area
```

- The normal and adjustable chair information should be in the following form:

```
"Type: {0}, Model: {1}, Material: {2}, Price: {3}, Height: {4}, Legs: {5}", this.GetType().Name, this.Model, this.Material, this.Price, this.Height, this.NumberOfLegs
```

- The convertible chair information should be in the following form:

```
"Type: {0}, Model: {1}, Material: {2}, Price: {3}, Height: {4}, Legs: {5}, State: {6}", this.GetType().Name, this.Model, this.Material, this.Price, this.Height, this.NumberOfLegs, this.IsConverted ? "Converted" : "Normal"
```

- The Type is either “Table“, or “Chair”, or “AdjustableChair” or “ConvertibleChair”. The convertible chair state is either “Converted” or “Normal”. All decimal type fields should be printed “as is”, without any formatting or rounding.

- All properties in the above interfaces are mandatory (cannot be null or empty).
- If a null value is passed to some mandatory property, you should use **defensive programming** to prevent unwanted results.


### Additional Notes
To simplify your work there is already working engine that executes a sequence of commands read from the console using the classes and interfaces in your project. Please put your classes in namespace **FurnitureManufacturer.Models**. Implement the **FurnitureFactory** class in the namespace **FurnitureManufacturer.Engine.Factories**.


Current implemented commands the engine supports are:
- **CreateCompany (name) (registration number)** – adds a company with given name and registration number. Duplicate names are not allowed. As a result the command returns “Company (name) created”.
- **AddFurnitureToCompany (company name) (furniture model)** – searches for furniture and adds it to an existing company’s catalog. As a result the command returns “Furniture (furniture model) added to company (company name)”.
- **RemoveFurnitureFromCompany (company name) (furniture model)** – searches for furniture and removes it from an existing company’s catalog. As a result the command returns “Furniture (furniture model) removed from company (company name)”.
- **FindFurnitureFromCompany (company name) (furniture model)** – searches for furniture in an existing company’s catalog. If found the engine prints the furniture’s ToString() method.
- **ShowCompanyCatalog (company name)** – searches for a company and invokes it’s Catalog() method.
- **CreateTable (model) (material) (price) (height) (length) (width)** – creates a table with given model, material, price, height, length and width. Duplicate models are not allowed. As a result the command returns “Table (model) created”.
- **CreateChair (model) (material) (price) (height) (legs) (type)** – creates a chair by given model, material, price, height, legs and type. Type can be “Normal”, “Adjustable” and “Convertible”. Duplicate models are not allowed. As a result the command returns “Chair (model) created”.
- **SetChairHeight (model) (height)** – searches for a chair by model and sets its height, if the chair is adjustable. As a result the command returns “Chair (model) adjusted to height (height)”.
- **ConvertChair (model)** – searches for a chair by model and converts its state, if the chair is convertible. As a result the command returns “Chair (model) converted”.
In case of invalid operation or error, the engine returns appropriate text messages.



**All commands return appropriate success messages. In case of invalid operation or error, the engine returns appropriate error messages.**


<img src="https://i.imgur.com/yqIN5FX.png" width="300px" />

## Step by step guide

**HINT** - **DO NOT** use the whole input as a test. Break it as simple as possible. Maybe one lne at a time is very good starting point.

**-1.** The classes are there. Use them with caution.

**0.** Implement all the interfaces. 

- Look at the Contracts folder and decide how to use any of the interfaces there.

**1.** General Hints

- You need to override ToString() in order to output the classes in the console.

**2.** You are given a skeleton of the Furniture Factory. Please take a look at it carefully before you try to do anything. Try to understand all the classes and interfaces and how the engine works. (You do not need to touch the engine at all).

**3.** Just build the project and look at the errors.
  - **HINT** implement the classes 
  - You already know how to do it. Use inheritance.
  - There is already a class called Furniture. How this could help you? (base class maybe)

**4.** Are there any other inheritance options? Do you have repeating code in more than one class?
  - Maybe another base class?

**5.** Take a look at the FurnitureFactory class
  - Is there an interface we could implement?

  ```
Severity Code Description Project File Line Suppression State
Error CS0266 Cannot implicitly convert type 'FurnitureManufacturer.Engine.Factories.FurnitureFactory' to 'FurnitureManufacturer.Interfaces.Engine.IFurnitureFactory'. An explicit conversion exists (are you missing a cast?)

```

  - How implementing the interface breaks our code?

**6.** How we can validate the that the string passed is a valid enum defined in our solution
  - Look inside FurnitureFactory class and use the method below

```cs
private MaterialType GetMaterialType(string material)
{
    switch (material)
    {
        case Wooden:
            return MaterialType.Wooden;
        case Leather:
            return MaterialType.Leather;
        case Plastic:
            return MaterialType.Plastic;
        default:
            throw new ArgumentException(string.Format(InvalidMaterialName, material));
    }
}
```




**7.** Validate all properties according to the guidelines set above

**HINT** on how to validate the company's registration number

```cs
if (!Regex.IsMatch(registrationNumber, "[0-9]{10}"))
{
    throw new ArgumentException("Registration number is not valid");
}
```

**8.** Implement the methods inside the Company class
  - You already know how to use LINQ with extension methods

```cs
var item = this.collection.FirstOrDefault(x => x.Name == name)
var ordered = this.collection.OrderBy(x => x.Price).ThemBy(x => x.Model)
```



### Sample Input

```
CreateCompany FurnitureTelerik 1234567890
ShowCompanyCatalog FurnitureTelerik
CreateTable SmallTable wooden 123.4 0.50 0.45 0.65
CreateChair TestChair leather 99.99 1.20 5 Normal
CreateChair MyChair leather 111.56 0.80 4 Adjustable
CreateChair NewChair plastic 80.00 1.00 3 Convertible
ShowCompanyCatalog FurnitureTelerik
AddFurnitureToCompany FurnitureTelerik SmallTable
AddFurnitureToCompany FurnitureTelerik TestChair
AddFurnitureToCompany FurnitureTelerik MyChair
AddFurnitureToCompany FurnitureTelerik NewChair
ShowCompanyCatalog FurnitureTelerik
RemoveFurnitureFromCompany FurnitureTelerik NewChair
ShowCompanyCatalog FurnitureTelerik
FindFurnitureFromCompany FurnitureTelerik MyChair
FindFurnitureFromCompany FurnitureTelerik NewChair
RemoveFurnitureFromCompany FurnitureTelerik MyChair
RemoveFurnitureFromCompany FurnitureTelerik SmallTable
ShowCompanyCatalog FurnitureTelerik
```

### Sample Output

```
Company FurnitureTelerik created
FurnitureTelerik - 1234567890 - no furnitures
Table SmallTable created
Chair TestChair created
Chair MyChair created
Chair NewChair created
FurnitureTelerik - 1234567890 - no furnitures
Furniture SmallTable added to company FurnitureTelerik
Furniture TestChair added to company FurnitureTelerik
Furniture MyChair added to company FurnitureTelerik
Furniture NewChair added to company FurnitureTelerik
FurnitureTelerik - 1234567890 - 4 furnitures
Type: ConvertibleChair, Model: NewChair, Material: Plastic, Price: 80.00, Height: 1.00, Legs: 3, State: Normal
Type: Chair, Model: TestChair, Material: Leather, Price: 99.99, Height: 1.20, Legs: 5
Type: AdjustableChair, Model: MyChair, Material: Leather, Price: 111.56, Height: 0.80, Legs: 4
Type: Table, Model: SmallTable, Material: Wooden, Price: 123.4, Height: 0.50, Length: 0.45, Width: 0.65, Area: 0.2925
Furniture NewChair removed from company FurnitureTelerik
FurnitureTelerik - 1234567890 - 3 furnitures
Type: Chair, Model: TestChair, Material: Leather, Price: 99.99, Height: 1.20, Legs: 5
Type: AdjustableChair, Model: MyChair, Material: Leather, Price: 111.56, Height: 0.80, Legs: 4
Type: Table, Model: SmallTable, Material: Wooden, Price: 123.4, Height: 0.50, Length: 0.45, Width: 0.65, Area: 0.2925
Type: AdjustableChair, Model: MyChair, Material: Leather, Price: 111.56, Height: 0.80, Legs: 4
Furniture NewChair not found
Furniture MyChair removed from company FurnitureTelerik
Furniture SmallTable removed from company FurnitureTelerik
FurnitureTelerik - 1234567890 - 1 furniture
Type: Chair, Model: TestChair, Material: Leather, Price: 99.99, Height: 1.20, Legs: 5
```
