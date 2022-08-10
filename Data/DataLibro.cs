using proyecto.Models;
using System.Data.SqlClient;
using System.Data;

namespace proyecto.Data
{
    public class DataLibro
    {
        // procedure spListar
        public List<ModelLibro> Listar()
        {
            var lista = new List<ModelLibro>();

            var cn = new Connection();

            using (var conexion = new SqlConnection(cn.CadenaSQL()))
            {
                conexion.Open();

                SqlCommand cmd = new SqlCommand("Listar", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                // dataReader = dr
                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        lista.Add(new ModelLibro()
                        {
                            // traemos los datos de ModelLibro y los relacionamos con el nombre de las columnas de la tabla
                            id = Convert.ToInt32(dr["id"]),
                            nombre = dr["nombre"].ToString(),
                            autor = dr["autor"].ToString(),
                            genero = dr["genero"].ToString(),
                            numPaginas = Convert.ToInt32(dr["numPaginas"].ToString()),
                            precio = Convert.ToInt32(dr["precio"].ToString())
                        });
                    }

                }
                conexion.Close();
                return lista;
            }
        }
        // procedure spObtener 
        public ModelLibro Obtener(int id)
        {
            var libro = new ModelLibro();
            var cn = new Connection();

            using (var conexion = new SqlConnection(cn.CadenaSQL()))
            {
                conexion.Open();

                SqlCommand cmd = new SqlCommand("Obtener", conexion);
                cmd.Parameters.AddWithValue("id", id);

                cmd.CommandType = CommandType.StoredProcedure;
                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        // traemos los datos de ModelLibro y los relacionamos con el nombre de las columnas de la tabla
                        libro.id = Convert.ToInt32(dr["id"]);
                        libro.nombre = dr["nombre"].ToString();
                        libro.autor = dr["autor"].ToString();
                        libro.genero = dr["genero"].ToString();
                        libro.numPaginas = Convert.ToInt32(dr["numPaginas"].ToString());
                        libro.precio = Convert.ToInt32(dr["precio"].ToString());
                    }
                }
                conexion.Close();
            }
            return libro;
        }

        // procedure spGuardar
        public bool Crear(ModelLibro libro)
        {
            bool response;

            try
            {
                var cn = new Connection();
                using (var conexion = new SqlConnection(cn.CadenaSQL()))
                {
                    conexion.Open();

                    SqlCommand cmd = new SqlCommand("Crear", conexion);
                    cmd.Parameters.AddWithValue("nombre", libro.nombre);
                    cmd.Parameters.AddWithValue("autor", libro.autor);
                    cmd.Parameters.AddWithValue("genero", libro.genero);
                    cmd.Parameters.AddWithValue("numPaginas", libro.numPaginas);
                    cmd.Parameters.AddWithValue("precio", libro.precio);

                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.ExecuteNonQuery();

                    conexion.Close();
                }
                // si sale bien
                response = true;
            }
            catch (Exception e)
            {
                string error = e.Message;
                // algo falló
                response = false;
            }
            return response;
        }

        // procedure spEditar
        public bool Editar(ModelLibro libro)
        {
            bool response;

            try
            {
                var cn = new Connection();
                using (var conexion = new SqlConnection(cn.CadenaSQL()))
                {
                    conexion.Open();

                    SqlCommand cmd = new SqlCommand("Editar", conexion);
                    cmd.Parameters.AddWithValue("id", libro.id);
                    cmd.Parameters.AddWithValue("nombre", libro.nombre);
                    cmd.Parameters.AddWithValue("autor", libro.autor);
                    cmd.Parameters.AddWithValue("genero", libro.genero);
                    cmd.Parameters.AddWithValue("numPaginas", libro.numPaginas);
                    cmd.Parameters.AddWithValue("precio", libro.precio);

                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.ExecuteNonQuery();

                    conexion.Close();
                }
                // si sale bien
                response = true;
            }
            catch (Exception e)
            {
                string error = e.Message;
                // algo falló
                response = false;
            }
            return response;
        }

        // procedure spEliminar
        public bool Eliminar(int id)
        {
            bool response;

            try
            {
                var cn = new Connection();
                using (var conexion = new SqlConnection(cn.CadenaSQL()))
                {
                    conexion.Open();

                    SqlCommand cmd = new SqlCommand("Eliminar", conexion);
                    cmd.Parameters.AddWithValue("id", id);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.ExecuteNonQuery();

                    conexion.Close();
                }
                // si sale bien
                response = true;
            }
            catch (Exception e)
            {
                string error = e.Message;
                // algo falló
                response = false;
            }
            return response;
        }
    }
}

