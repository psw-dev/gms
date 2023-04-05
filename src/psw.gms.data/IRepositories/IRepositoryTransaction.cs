/*This code is a generated one , Change the source code of the generator if you want some change in this code
You can find the source code of the code generator from here -> https://git.psw.gov.pk/unais.vayani/DalGenerator*/

using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

using PSW.GMS.Data.Entities;

namespace PSW.GMS.Data.Repositories
{
	public interface IRepositoryTransaction
    {
		#region Methods

        void SetTransaction(IDbTransaction transaction);

		#endregion
    }
}
