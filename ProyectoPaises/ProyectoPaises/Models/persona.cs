//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ProyectoPaises.Models
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Data;
    using System.Data.SqlClient;

    public partial class persona
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public persona()
        {
            this.pais = new HashSet<pais>();
        }
    
        public static List<persona> actualizadas = new List<persona>();
        public static List<persona> borradas = new List<persona>();
        public static List<persona> insertadas = new List<persona>();

        public decimal cedula { get; set; }
        public string nbrPersona { get; set; }
        public decimal paisNacimiento { get; set; }
        public decimal paisResidencia { get; set; }
        public Nullable<System.DateTime> fchNacimiento { get; set; }
        public string correo { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<pais> pais { get; set; }
        public virtual pais pais1 { get; set; }
        public virtual pais pais2 { get; set; }

        public List<persona> Listar(decimal idPais, int pageIndex, int pageSize, out int pageCount)
        {
            List<persona> orders = new List<persona>();
            using (SqlConnection conexion = new SqlConnection("Data Source=ecRhin.ec.tec.ac.cr\\Estudiantes;Initial Catalog=proyectoBases2;Persist Security Info=True;User ID=josepalvarado;Password=josepalvarado;MultipleActiveResultSets=True;Application Name=EntityFramework"))
            {
                conexion.Open();
                using (SqlCommand comando = new SqlCommand("paginarPersonasPorPais", conexion))
                {
                    comando.CommandType = CommandType.StoredProcedure;
                    comando.CommandTimeout = 0;
                    comando.Parameters.AddWithValue("@idPais", idPais);
                    comando.Parameters.AddWithValue("@pageIndex", pageIndex);
                    comando.Parameters.AddWithValue("@pageSize", pageSize);
                    comando.Parameters.AddWithValue("@pageCount", 0).Direction = ParameterDirection.Output;
                    using (SqlDataReader reader = comando.ExecuteReader())
                    {
                        if (reader != null)
                        {
                            persona order = null;
                            while (reader.Read())
                            {
                                order = new persona();
                                order.cedula = (decimal)reader["cedula"];
                                order.nbrPersona = (string)reader["nbrPersona"];
                                order.paisNacimiento = (decimal)reader["paisNacimiento"];
                                order.paisResidencia = (decimal)reader["paisResidencia"];
                                order.fchNacimiento = (System.DateTime)reader["fchNacimiento"];
                                order.correo = (string)reader["correo"];
                                orders.Add(order);
                            }
                        }
                    }
                    pageCount = (int)comando.Parameters["@pageCount"].Value;
                }
            }
            return orders;
        }

    }
}
