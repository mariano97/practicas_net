using ApiDevelop.Services.Mappers.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiDevelop.Services
{
    public interface ICategoriaService
    {

        List<CategoriaDTO> GetAllCategorias();
        CategoriaDTO GetCategoriaById(int id);
        bool SaveProducto(CategoriaDTO categoriaDTO);
        void DeleteProducto(CategoriaDTO categoriaDTO);

    }
}
