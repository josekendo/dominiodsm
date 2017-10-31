

using System;
using System.Text;

using NHibernate;
using NHibernate.Cfg;
using NHibernate.Criterion;
using NHibernate.Exceptions;
using DominiolifetagGenNHibernate.Exceptions;

using DominiolifetagGenNHibernate.EN.Dominiolifetag;
using DominiolifetagGenNHibernate.CAD.Dominiolifetag;


namespace DominiolifetagGenNHibernate.CEN.Dominiolifetag
{
/*
 *      Definition of the class CategoriaCEN
 *
 */
public partial class CategoriaCEN
{
private ICategoriaCAD _ICategoriaCAD;

public CategoriaCEN()
{
        this._ICategoriaCAD = new CategoriaCAD ();
}

public CategoriaCEN(ICategoriaCAD _ICategoriaCAD)
{
        this._ICategoriaCAD = _ICategoriaCAD;
}

public ICategoriaCAD get_ICategoriaCAD ()
{
        return this._ICategoriaCAD;
}

public int New_ (string p_nombre, string p_descripcion, int p_edad)
{
        CategoriaEN categoriaEN = null;
        int oid;

        //Initialized CategoriaEN
        categoriaEN = new CategoriaEN ();
        categoriaEN.Nombre = p_nombre;

        categoriaEN.Descripcion = p_descripcion;

        categoriaEN.Edad = p_edad;

        //Call to CategoriaCAD

        oid = _ICategoriaCAD.New_ (categoriaEN);
        return oid;
}

public void Modify (int p_Categoria_OID, string p_nombre, string p_descripcion, int p_edad)
{
        CategoriaEN categoriaEN = null;

        //Initialized CategoriaEN
        categoriaEN = new CategoriaEN ();
        categoriaEN.ID = p_Categoria_OID;
        categoriaEN.Nombre = p_nombre;
        categoriaEN.Descripcion = p_descripcion;
        categoriaEN.Edad = p_edad;
        //Call to CategoriaCAD

        _ICategoriaCAD.Modify (categoriaEN);
}

public void Destroy (int ID
                     )
{
        _ICategoriaCAD.Destroy (ID);
}

public System.Collections.Generic.IList<CategoriaEN> ListadoCategorias (int first, int size)
{
        System.Collections.Generic.IList<CategoriaEN> list = null;

        list = _ICategoriaCAD.ListadoCategorias (first, size);
        return list;
}
}
}
