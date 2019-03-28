# GenericCodebook
Generic codebook construction


Construction for fast building Codebooks and registries.

Steps:
  Server side:
    1. Create mapper that implements atleast IDomainSideMapper
    2. Create Service. 
        Extend BaseCodeBookService.
        Implement ICodeBookService, ISuggestionService
    3. Register service in CodeBookDependencyResolver and SuggestionDependencyResolver
    4. Register Service in IServiceCollection

  Client side:
    1. Create configuration for new codebook (codebook-configuration.ts)
    2. Register route in codebook.routing.ts
    3. (optional) Add route in navigation menu
    
Enjoy
 
 
 !Important!
 Not all functionalities are implemented because I didn't want to harcode this to one framework. 
 I order to fully use this you have to implement this in regards to yours framework.
 
 TODO: IMPLEMENT ROUTING BY ID BETWEEN CODEBOOKS
  
  
  Example of configuration for specific cases:
  
 Example 1:
                    ...
                        {
                          field: 'TestOption',
                          header: "Test",
                          type: "autocomplete",
                          fk_prop: "Text",  //Shows from column that fk points this property
                          fk: "TestOption", // Points on that column
                          suggestions: 'SIF_TEST',  // Used for autocomplete and dropdowns
                          detailsShow: true,
                          required: true,
                          routerField: "TestOption.Id", // Id which will be injected in route. 
                          routerLink: TEST_ROUTE, // path
                          width: '20%',
                          filter: false,
                          gridShow: false,
                          fk_prop2: null,
                          disabled: false,
                          sortable: false,
                          editShow: true,
                          additional_info: null,
                          multiple: false,
                          columns: 1,
                        },
                    ...
                    
 Example 2:
                    ...
                          {
                            field: 'Test2Option',
                            header: "Test 2",
                            type: "autocomplete",
                            fk_prop: "Text",
                            fk: "Test2Option",
                            suggestions: 'SIF_TEST2',
                            detailsShow: true,
                            required: false,
                            width: '20%',
                            filter: false,
                            gridShow: false,
                            fk_prop2: null,
                            disabled: false,
                            sortable: false,
                            editShow: true,
                            additional_info: [new KeyValue('filterBy', "TestOption"), new KeyValue('dependantField', "TestOption")], // Filter by is used for subseting result in autocomplete (ISuggestionService). dependantField is used for disabling field while dependant is null. 
                            multiple: false,
                            columns: 1,
                            routerField: null,
                            routerLink: null,
                          },
                    ...
