using System.Data.SqlClient;

namespace InterfaceContamination
{
	public interface IDatabase
	{
		SqlParameter CalculateInvoicesReport();
	}
}
