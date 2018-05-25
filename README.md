# graphql-api
Sample API using GraphQL for .NET

Some test queries:

Brands:
```
{
	"query": "{ brands { id, name } }"
}
```

Products:
```
{
	"query": "{ products { id, name }}"
}
```

Full Products:
```
{
	"query": "{ products { id, name, brandName, comments { text, author, createdAt }, images {url}}}"
}
```

