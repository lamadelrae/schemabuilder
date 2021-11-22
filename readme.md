## Schema builder project in .NET 6.
<br/>
Syntax: 
```
public class DataScript : Script
{
	public DataScript() : base(1)
	{
		Add().Table("TableName")
			.Column("Test", x => x.Int());
	}
}

public class AnotherDataScript : Script
{
	public AnotherDataScript() : base(2)
	{
		Add().Column("ColumnName", x => x.Guid())
			.To("TableName");
	}
}

public class DataRenaming : Script
{
	public DataMigrations() : base(3)
	{
		// Has to have same structure.
		Rename()
			.Table("SomeTable")
			.To("AnotherTable")

		Rename()
			.Column("SomeColumn").In("Table")
			.To("AnotherTable");
	}
}
```
As you can see, we have a structure where each class is a script, and when you instance the Script, you have to inform the script id.
Internally, the schema builder is going to order these scripts by their id and execute them, so it is very important to never alter the order of the scripts.
SchemaBuilder will create an internal table to store all the Scripts so it knows what to run and what not to run.