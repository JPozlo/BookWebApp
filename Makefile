# Project Variables

 PROJECT_NAME ?= Books
.PHONY: migrations db

migrations:
	cd ./Books.Data && dotnet ef migrations add $(mname) --startup-project ../Books.Web && cd ..

db:
	cd ./Books.Data && dotnet ef database update --startup-project ../Books.Web && cd ..

