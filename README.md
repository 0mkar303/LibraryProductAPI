This module is part of the Library Management System.
It provides CRUD operations, search, and pagination for managing books.


Models/
   Books/
      Book.cs

DTO/
   Books/
      BookCreateDto.cs
      BookUpdateDto.cs

Repository/
   Books/
      IBookRepository.cs
      BookRepository.cs

Controllers/
   BooksController.cs


Connection String

"ConnectionStrings": {
  "DefaultConnection": "Server=(localdb)\\MSSQLLocalDB;Database=LibraryProductDb;Trusted_Connection=True;"
}

migration Command that used

Add-Migration Initial
Update-Database
# LibraryProductAPI
