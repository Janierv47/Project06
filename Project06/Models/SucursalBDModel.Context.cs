﻿//------------------------------------------------------------------------------
// <auto-generated>
//    Este código se generó a partir de una plantilla.
//
//    Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//    Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Project06.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Objects;
    using System.Data.Objects.DataClasses;
    using System.Linq;
    
    public partial class proyecto06Entities : DbContext
    {
        public proyecto06Entities()
            : base("name=proyecto06Entities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public DbSet<sysdiagrams> sysdiagrams { get; set; }
        public DbSet<tblCliente> tblCliente { get; set; }
        public DbSet<tblCuenta> tblCuenta { get; set; }
        public DbSet<tblinicioSesion> tblinicioSesion { get; set; }
        public DbSet<tblMoneda> tblMoneda { get; set; }
        public DbSet<tblMovimiento> tblMovimiento { get; set; }
        public DbSet<tblTipoCliente> tblTipoCliente { get; set; }
        public DbSet<tblTipoCuenta> tblTipoCuenta { get; set; }
        public DbSet<tblTipoMovimiento> tblTipoMovimiento { get; set; }
        public DbSet<tblTipoUsuario> tblTipoUsuario { get; set; }
        public DbSet<VW_Ejemplo> VW_Ejemplo { get; set; }
    
        public virtual int sp_alterdiagram(string diagramname, Nullable<int> owner_id, Nullable<int> version, byte[] definition)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            var versionParameter = version.HasValue ?
                new ObjectParameter("version", version) :
                new ObjectParameter("version", typeof(int));
    
            var definitionParameter = definition != null ?
                new ObjectParameter("definition", definition) :
                new ObjectParameter("definition", typeof(byte[]));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_alterdiagram", diagramnameParameter, owner_idParameter, versionParameter, definitionParameter);
        }
    
        public virtual ObjectResult<sp_AutenticacionUsuario_Result> sp_AutenticacionUsuario(string usuario, Nullable<int> contraseña)
        {
            var usuarioParameter = usuario != null ?
                new ObjectParameter("usuario", usuario) :
                new ObjectParameter("usuario", typeof(string));
    
            var contraseñaParameter = contraseña.HasValue ?
                new ObjectParameter("contraseña", contraseña) :
                new ObjectParameter("contraseña", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_AutenticacionUsuario_Result>("sp_AutenticacionUsuario", usuarioParameter, contraseñaParameter);
        }
    
        public virtual ObjectResult<sp_ConsultarTiposMovimientos_Result> sp_ConsultarTiposMovimientos()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_ConsultarTiposMovimientos_Result>("sp_ConsultarTiposMovimientos");
        }
    
        public virtual int sp_creatediagram(string diagramname, Nullable<int> owner_id, Nullable<int> version, byte[] definition)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            var versionParameter = version.HasValue ?
                new ObjectParameter("version", version) :
                new ObjectParameter("version", typeof(int));
    
            var definitionParameter = definition != null ?
                new ObjectParameter("definition", definition) :
                new ObjectParameter("definition", typeof(byte[]));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_creatediagram", diagramnameParameter, owner_idParameter, versionParameter, definitionParameter);
        }
    
        public virtual ObjectResult<sp_CuentasDestino_Result> sp_CuentasDestino(Nullable<int> id_cuenta)
        {
            var id_cuentaParameter = id_cuenta.HasValue ?
                new ObjectParameter("id_cuenta", id_cuenta) :
                new ObjectParameter("id_cuenta", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_CuentasDestino_Result>("sp_CuentasDestino", id_cuentaParameter);
        }
    
        public virtual ObjectResult<sp_CuentasUsuario_Result> sp_CuentasUsuario(Nullable<int> id_cliente)
        {
            var id_clienteParameter = id_cliente.HasValue ?
                new ObjectParameter("id_cliente", id_cliente) :
                new ObjectParameter("id_cliente", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_CuentasUsuario_Result>("sp_CuentasUsuario", id_clienteParameter);
        }
    
        public virtual int sp_DeleteCliente(Nullable<int> id_cliente)
        {
            var id_clienteParameter = id_cliente.HasValue ?
                new ObjectParameter("id_cliente", id_cliente) :
                new ObjectParameter("id_cliente", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_DeleteCliente", id_clienteParameter);
        }
    
        public virtual int sp_DeleteCuenta(Nullable<int> id_cuenta)
        {
            var id_cuentaParameter = id_cuenta.HasValue ?
                new ObjectParameter("id_cuenta", id_cuenta) :
                new ObjectParameter("id_cuenta", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_DeleteCuenta", id_cuentaParameter);
        }
    
        public virtual int sp_DeleteMoneda(Nullable<int> id_moneda)
        {
            var id_monedaParameter = id_moneda.HasValue ?
                new ObjectParameter("id_moneda", id_moneda) :
                new ObjectParameter("id_moneda", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_DeleteMoneda", id_monedaParameter);
        }
    
        public virtual int sp_DeleteTipoCliente(Nullable<int> id_tipoCliente)
        {
            var id_tipoClienteParameter = id_tipoCliente.HasValue ?
                new ObjectParameter("id_tipoCliente", id_tipoCliente) :
                new ObjectParameter("id_tipoCliente", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_DeleteTipoCliente", id_tipoClienteParameter);
        }
    
        public virtual int sp_DeleteTipoCuenta(Nullable<int> id_tipoCuenta)
        {
            var id_tipoCuentaParameter = id_tipoCuenta.HasValue ?
                new ObjectParameter("id_tipoCuenta", id_tipoCuenta) :
                new ObjectParameter("id_tipoCuenta", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_DeleteTipoCuenta", id_tipoCuentaParameter);
        }
    
        public virtual int sp_Deposito(Nullable<int> id_TipoMovimiento, Nullable<int> id_Cuenta, Nullable<double> monto, Nullable<System.DateTime> fechaDelMovimiento)
        {
            var id_TipoMovimientoParameter = id_TipoMovimiento.HasValue ?
                new ObjectParameter("id_TipoMovimiento", id_TipoMovimiento) :
                new ObjectParameter("id_TipoMovimiento", typeof(int));
    
            var id_CuentaParameter = id_Cuenta.HasValue ?
                new ObjectParameter("id_Cuenta", id_Cuenta) :
                new ObjectParameter("id_Cuenta", typeof(int));
    
            var montoParameter = monto.HasValue ?
                new ObjectParameter("monto", monto) :
                new ObjectParameter("monto", typeof(double));
    
            var fechaDelMovimientoParameter = fechaDelMovimiento.HasValue ?
                new ObjectParameter("fechaDelMovimiento", fechaDelMovimiento) :
                new ObjectParameter("fechaDelMovimiento", typeof(System.DateTime));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_Deposito", id_TipoMovimientoParameter, id_CuentaParameter, montoParameter, fechaDelMovimientoParameter);
        }
    
        public virtual int sp_dropdiagram(string diagramname, Nullable<int> owner_id)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_dropdiagram", diagramnameParameter, owner_idParameter);
        }
    
        public virtual ObjectResult<sp_helpdiagramdefinition_Result> sp_helpdiagramdefinition(string diagramname, Nullable<int> owner_id)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_helpdiagramdefinition_Result>("sp_helpdiagramdefinition", diagramnameParameter, owner_idParameter);
        }
    
        public virtual ObjectResult<sp_helpdiagrams_Result> sp_helpdiagrams(string diagramname, Nullable<int> owner_id)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_helpdiagrams_Result>("sp_helpdiagrams", diagramnameParameter, owner_idParameter);
        }
    
        public virtual int sp_InsertCliente(Nullable<int> id_tipoCliente, Nullable<int> cedula, string genero, Nullable<System.DateTime> fechaNacimiento, string primerApellido, string segundoApellido, string nombre, string direccionFisica, string telefonoPrincipal, string telefonoSecundario, string correo)
        {
            var id_tipoClienteParameter = id_tipoCliente.HasValue ?
                new ObjectParameter("id_tipoCliente", id_tipoCliente) :
                new ObjectParameter("id_tipoCliente", typeof(int));
    
            var cedulaParameter = cedula.HasValue ?
                new ObjectParameter("cedula", cedula) :
                new ObjectParameter("cedula", typeof(int));
    
            var generoParameter = genero != null ?
                new ObjectParameter("genero", genero) :
                new ObjectParameter("genero", typeof(string));
    
            var fechaNacimientoParameter = fechaNacimiento.HasValue ?
                new ObjectParameter("fechaNacimiento", fechaNacimiento) :
                new ObjectParameter("fechaNacimiento", typeof(System.DateTime));
    
            var primerApellidoParameter = primerApellido != null ?
                new ObjectParameter("primerApellido", primerApellido) :
                new ObjectParameter("primerApellido", typeof(string));
    
            var segundoApellidoParameter = segundoApellido != null ?
                new ObjectParameter("segundoApellido", segundoApellido) :
                new ObjectParameter("segundoApellido", typeof(string));
    
            var nombreParameter = nombre != null ?
                new ObjectParameter("nombre", nombre) :
                new ObjectParameter("nombre", typeof(string));
    
            var direccionFisicaParameter = direccionFisica != null ?
                new ObjectParameter("direccionFisica", direccionFisica) :
                new ObjectParameter("direccionFisica", typeof(string));
    
            var telefonoPrincipalParameter = telefonoPrincipal != null ?
                new ObjectParameter("telefonoPrincipal", telefonoPrincipal) :
                new ObjectParameter("telefonoPrincipal", typeof(string));
    
            var telefonoSecundarioParameter = telefonoSecundario != null ?
                new ObjectParameter("telefonoSecundario", telefonoSecundario) :
                new ObjectParameter("telefonoSecundario", typeof(string));
    
            var correoParameter = correo != null ?
                new ObjectParameter("correo", correo) :
                new ObjectParameter("correo", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_InsertCliente", id_tipoClienteParameter, cedulaParameter, generoParameter, fechaNacimientoParameter, primerApellidoParameter, segundoApellidoParameter, nombreParameter, direccionFisicaParameter, telefonoPrincipalParameter, telefonoSecundarioParameter, correoParameter);
        }
    
        public virtual int sp_InsertCuenta(Nullable<int> numeroCuenta, Nullable<int> id_cliente, Nullable<int> id_tipoCuenta, Nullable<int> id_moneda, Nullable<double> saldo, Nullable<int> estado)
        {
            var numeroCuentaParameter = numeroCuenta.HasValue ?
                new ObjectParameter("numeroCuenta", numeroCuenta) :
                new ObjectParameter("numeroCuenta", typeof(int));
    
            var id_clienteParameter = id_cliente.HasValue ?
                new ObjectParameter("id_cliente", id_cliente) :
                new ObjectParameter("id_cliente", typeof(int));
    
            var id_tipoCuentaParameter = id_tipoCuenta.HasValue ?
                new ObjectParameter("id_tipoCuenta", id_tipoCuenta) :
                new ObjectParameter("id_tipoCuenta", typeof(int));
    
            var id_monedaParameter = id_moneda.HasValue ?
                new ObjectParameter("id_moneda", id_moneda) :
                new ObjectParameter("id_moneda", typeof(int));
    
            var saldoParameter = saldo.HasValue ?
                new ObjectParameter("saldo", saldo) :
                new ObjectParameter("saldo", typeof(double));
    
            var estadoParameter = estado.HasValue ?
                new ObjectParameter("estado", estado) :
                new ObjectParameter("estado", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_InsertCuenta", numeroCuentaParameter, id_clienteParameter, id_tipoCuentaParameter, id_monedaParameter, saldoParameter, estadoParameter);
        }
    
        public virtual int sp_InsertMoneda(string nombre, string codigo, Nullable<double> tipoCambio)
        {
            var nombreParameter = nombre != null ?
                new ObjectParameter("nombre", nombre) :
                new ObjectParameter("nombre", typeof(string));
    
            var codigoParameter = codigo != null ?
                new ObjectParameter("codigo", codigo) :
                new ObjectParameter("codigo", typeof(string));
    
            var tipoCambioParameter = tipoCambio.HasValue ?
                new ObjectParameter("tipoCambio", tipoCambio) :
                new ObjectParameter("tipoCambio", typeof(double));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_InsertMoneda", nombreParameter, codigoParameter, tipoCambioParameter);
        }
    
        public virtual int sp_InsertTipoCliente(string nombre, string descripcion)
        {
            var nombreParameter = nombre != null ?
                new ObjectParameter("nombre", nombre) :
                new ObjectParameter("nombre", typeof(string));
    
            var descripcionParameter = descripcion != null ?
                new ObjectParameter("descripcion", descripcion) :
                new ObjectParameter("descripcion", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_InsertTipoCliente", nombreParameter, descripcionParameter);
        }
    
        public virtual int sp_InsertTipoCuenta(string nombre, string codigo)
        {
            var nombreParameter = nombre != null ?
                new ObjectParameter("nombre", nombre) :
                new ObjectParameter("nombre", typeof(string));
    
            var codigoParameter = codigo != null ?
                new ObjectParameter("codigo", codigo) :
                new ObjectParameter("codigo", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_InsertTipoCuenta", nombreParameter, codigoParameter);
        }
    
        public virtual int sp_renamediagram(string diagramname, Nullable<int> owner_id, string new_diagramname)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            var new_diagramnameParameter = new_diagramname != null ?
                new ObjectParameter("new_diagramname", new_diagramname) :
                new ObjectParameter("new_diagramname", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_renamediagram", diagramnameParameter, owner_idParameter, new_diagramnameParameter);
        }
    
        public virtual int sp_Retiro(Nullable<int> id_Cuenta, Nullable<double> monto, Nullable<System.DateTime> fechaDelMovimiento)
        {
            var id_CuentaParameter = id_Cuenta.HasValue ?
                new ObjectParameter("id_Cuenta", id_Cuenta) :
                new ObjectParameter("id_Cuenta", typeof(int));
    
            var montoParameter = monto.HasValue ?
                new ObjectParameter("monto", monto) :
                new ObjectParameter("monto", typeof(double));
    
            var fechaDelMovimientoParameter = fechaDelMovimiento.HasValue ?
                new ObjectParameter("fechaDelMovimiento", fechaDelMovimiento) :
                new ObjectParameter("fechaDelMovimiento", typeof(System.DateTime));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_Retiro", id_CuentaParameter, montoParameter, fechaDelMovimientoParameter);
        }
    
        public virtual ObjectResult<sp_RetornaClienteID_Result> sp_RetornaClienteID(Nullable<int> id_cliente)
        {
            var id_clienteParameter = id_cliente.HasValue ?
                new ObjectParameter("id_cliente", id_cliente) :
                new ObjectParameter("id_cliente", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_RetornaClienteID_Result>("sp_RetornaClienteID", id_clienteParameter);
        }
    
        public virtual ObjectResult<sp_RetornaCuentaID_Result> sp_RetornaCuentaID(Nullable<int> id_cuenta)
        {
            var id_cuentaParameter = id_cuenta.HasValue ?
                new ObjectParameter("id_cuenta", id_cuenta) :
                new ObjectParameter("id_cuenta", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_RetornaCuentaID_Result>("sp_RetornaCuentaID", id_cuentaParameter);
        }
    
        public virtual ObjectResult<sp_RetornaCuentas_Result> sp_RetornaCuentas(Nullable<int> numeroCuenta)
        {
            var numeroCuentaParameter = numeroCuenta.HasValue ?
                new ObjectParameter("numeroCuenta", numeroCuenta) :
                new ObjectParameter("numeroCuenta", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_RetornaCuentas_Result>("sp_RetornaCuentas", numeroCuentaParameter);
        }
    
        public virtual ObjectResult<sp_RetornaMoneda_Result> sp_RetornaMoneda(string nombre, string codigo, Nullable<double> tipoCambio)
        {
            var nombreParameter = nombre != null ?
                new ObjectParameter("nombre", nombre) :
                new ObjectParameter("nombre", typeof(string));
    
            var codigoParameter = codigo != null ?
                new ObjectParameter("codigo", codigo) :
                new ObjectParameter("codigo", typeof(string));
    
            var tipoCambioParameter = tipoCambio.HasValue ?
                new ObjectParameter("tipoCambio", tipoCambio) :
                new ObjectParameter("tipoCambio", typeof(double));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_RetornaMoneda_Result>("sp_RetornaMoneda", nombreParameter, codigoParameter, tipoCambioParameter);
        }
    
        public virtual ObjectResult<sp_RetornaMonedaID_Result> sp_RetornaMonedaID(Nullable<int> id_moneda)
        {
            var id_monedaParameter = id_moneda.HasValue ?
                new ObjectParameter("id_moneda", id_moneda) :
                new ObjectParameter("id_moneda", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_RetornaMonedaID_Result>("sp_RetornaMonedaID", id_monedaParameter);
        }
    
        public virtual ObjectResult<sp_RetornaTipoClienteID_Result> sp_RetornaTipoClienteID(Nullable<int> id_tipoCliente)
        {
            var id_tipoClienteParameter = id_tipoCliente.HasValue ?
                new ObjectParameter("id_tipoCliente", id_tipoCliente) :
                new ObjectParameter("id_tipoCliente", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_RetornaTipoClienteID_Result>("sp_RetornaTipoClienteID", id_tipoClienteParameter);
        }
    
        public virtual ObjectResult<sp_RetornaTipoCuenta_Result> sp_RetornaTipoCuenta(string nombre, string codigo)
        {
            var nombreParameter = nombre != null ?
                new ObjectParameter("nombre", nombre) :
                new ObjectParameter("nombre", typeof(string));
    
            var codigoParameter = codigo != null ?
                new ObjectParameter("codigo", codigo) :
                new ObjectParameter("codigo", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_RetornaTipoCuenta_Result>("sp_RetornaTipoCuenta", nombreParameter, codigoParameter);
        }
    
        public virtual ObjectResult<sp_RetornaTipoCuentaID_Result> sp_RetornaTipoCuentaID(Nullable<int> id_tipoCuenta)
        {
            var id_tipoCuentaParameter = id_tipoCuenta.HasValue ?
                new ObjectParameter("id_tipoCuenta", id_tipoCuenta) :
                new ObjectParameter("id_tipoCuenta", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_RetornaTipoCuentaID_Result>("sp_RetornaTipoCuentaID", id_tipoCuentaParameter);
        }
    
        public virtual int sp_Transferencias(Nullable<double> monto, Nullable<int> id_CuentaOrigen, Nullable<int> id_CuentaDestino, Nullable<System.DateTime> fechaTransferencia)
        {
            var montoParameter = monto.HasValue ?
                new ObjectParameter("monto", monto) :
                new ObjectParameter("monto", typeof(double));
    
            var id_CuentaOrigenParameter = id_CuentaOrigen.HasValue ?
                new ObjectParameter("id_CuentaOrigen", id_CuentaOrigen) :
                new ObjectParameter("id_CuentaOrigen", typeof(int));
    
            var id_CuentaDestinoParameter = id_CuentaDestino.HasValue ?
                new ObjectParameter("id_CuentaDestino", id_CuentaDestino) :
                new ObjectParameter("id_CuentaDestino", typeof(int));
    
            var fechaTransferenciaParameter = fechaTransferencia.HasValue ?
                new ObjectParameter("fechaTransferencia", fechaTransferencia) :
                new ObjectParameter("fechaTransferencia", typeof(System.DateTime));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_Transferencias", montoParameter, id_CuentaOrigenParameter, id_CuentaDestinoParameter, fechaTransferenciaParameter);
        }
    
        public virtual int sp_UpdateCliente(Nullable<int> id_cliente, Nullable<int> id_tipoCliente, Nullable<int> cedula, string genero, Nullable<System.DateTime> fechaNacimiento, string primerApellido, string segundoApellido, string nombre, string direccionFisica, string telefonoPrincipal, string telefonoSecundario, string correo)
        {
            var id_clienteParameter = id_cliente.HasValue ?
                new ObjectParameter("id_cliente", id_cliente) :
                new ObjectParameter("id_cliente", typeof(int));
    
            var id_tipoClienteParameter = id_tipoCliente.HasValue ?
                new ObjectParameter("id_tipoCliente", id_tipoCliente) :
                new ObjectParameter("id_tipoCliente", typeof(int));
    
            var cedulaParameter = cedula.HasValue ?
                new ObjectParameter("cedula", cedula) :
                new ObjectParameter("cedula", typeof(int));
    
            var generoParameter = genero != null ?
                new ObjectParameter("genero", genero) :
                new ObjectParameter("genero", typeof(string));
    
            var fechaNacimientoParameter = fechaNacimiento.HasValue ?
                new ObjectParameter("fechaNacimiento", fechaNacimiento) :
                new ObjectParameter("fechaNacimiento", typeof(System.DateTime));
    
            var primerApellidoParameter = primerApellido != null ?
                new ObjectParameter("primerApellido", primerApellido) :
                new ObjectParameter("primerApellido", typeof(string));
    
            var segundoApellidoParameter = segundoApellido != null ?
                new ObjectParameter("segundoApellido", segundoApellido) :
                new ObjectParameter("segundoApellido", typeof(string));
    
            var nombreParameter = nombre != null ?
                new ObjectParameter("nombre", nombre) :
                new ObjectParameter("nombre", typeof(string));
    
            var direccionFisicaParameter = direccionFisica != null ?
                new ObjectParameter("direccionFisica", direccionFisica) :
                new ObjectParameter("direccionFisica", typeof(string));
    
            var telefonoPrincipalParameter = telefonoPrincipal != null ?
                new ObjectParameter("telefonoPrincipal", telefonoPrincipal) :
                new ObjectParameter("telefonoPrincipal", typeof(string));
    
            var telefonoSecundarioParameter = telefonoSecundario != null ?
                new ObjectParameter("telefonoSecundario", telefonoSecundario) :
                new ObjectParameter("telefonoSecundario", typeof(string));
    
            var correoParameter = correo != null ?
                new ObjectParameter("correo", correo) :
                new ObjectParameter("correo", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_UpdateCliente", id_clienteParameter, id_tipoClienteParameter, cedulaParameter, generoParameter, fechaNacimientoParameter, primerApellidoParameter, segundoApellidoParameter, nombreParameter, direccionFisicaParameter, telefonoPrincipalParameter, telefonoSecundarioParameter, correoParameter);
        }
    
        public virtual int sp_UpdateCuenta(Nullable<int> id_cuenta, Nullable<int> numeroCuenta, Nullable<int> id_cliente, Nullable<int> id_tipoCuenta, Nullable<int> id_moneda, Nullable<double> saldo, Nullable<int> estado)
        {
            var id_cuentaParameter = id_cuenta.HasValue ?
                new ObjectParameter("id_cuenta", id_cuenta) :
                new ObjectParameter("id_cuenta", typeof(int));
    
            var numeroCuentaParameter = numeroCuenta.HasValue ?
                new ObjectParameter("numeroCuenta", numeroCuenta) :
                new ObjectParameter("numeroCuenta", typeof(int));
    
            var id_clienteParameter = id_cliente.HasValue ?
                new ObjectParameter("id_cliente", id_cliente) :
                new ObjectParameter("id_cliente", typeof(int));
    
            var id_tipoCuentaParameter = id_tipoCuenta.HasValue ?
                new ObjectParameter("id_tipoCuenta", id_tipoCuenta) :
                new ObjectParameter("id_tipoCuenta", typeof(int));
    
            var id_monedaParameter = id_moneda.HasValue ?
                new ObjectParameter("id_moneda", id_moneda) :
                new ObjectParameter("id_moneda", typeof(int));
    
            var saldoParameter = saldo.HasValue ?
                new ObjectParameter("saldo", saldo) :
                new ObjectParameter("saldo", typeof(double));
    
            var estadoParameter = estado.HasValue ?
                new ObjectParameter("estado", estado) :
                new ObjectParameter("estado", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_UpdateCuenta", id_cuentaParameter, numeroCuentaParameter, id_clienteParameter, id_tipoCuentaParameter, id_monedaParameter, saldoParameter, estadoParameter);
        }
    
        public virtual int sp_UpdateMoneda(Nullable<int> id_moneda, string nombre, string codigo, Nullable<double> tipoCambio)
        {
            var id_monedaParameter = id_moneda.HasValue ?
                new ObjectParameter("id_moneda", id_moneda) :
                new ObjectParameter("id_moneda", typeof(int));
    
            var nombreParameter = nombre != null ?
                new ObjectParameter("nombre", nombre) :
                new ObjectParameter("nombre", typeof(string));
    
            var codigoParameter = codigo != null ?
                new ObjectParameter("codigo", codigo) :
                new ObjectParameter("codigo", typeof(string));
    
            var tipoCambioParameter = tipoCambio.HasValue ?
                new ObjectParameter("tipoCambio", tipoCambio) :
                new ObjectParameter("tipoCambio", typeof(double));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_UpdateMoneda", id_monedaParameter, nombreParameter, codigoParameter, tipoCambioParameter);
        }
    
        public virtual int sp_UpdateTipoCliente(Nullable<int> id_tipoCliente, string nombre, string descripcion)
        {
            var id_tipoClienteParameter = id_tipoCliente.HasValue ?
                new ObjectParameter("id_tipoCliente", id_tipoCliente) :
                new ObjectParameter("id_tipoCliente", typeof(int));
    
            var nombreParameter = nombre != null ?
                new ObjectParameter("nombre", nombre) :
                new ObjectParameter("nombre", typeof(string));
    
            var descripcionParameter = descripcion != null ?
                new ObjectParameter("descripcion", descripcion) :
                new ObjectParameter("descripcion", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_UpdateTipoCliente", id_tipoClienteParameter, nombreParameter, descripcionParameter);
        }
    
        public virtual int sp_UpdateTipoCuenta(Nullable<int> id_tipoCuenta, string nombre, string codigo)
        {
            var id_tipoCuentaParameter = id_tipoCuenta.HasValue ?
                new ObjectParameter("id_tipoCuenta", id_tipoCuenta) :
                new ObjectParameter("id_tipoCuenta", typeof(int));
    
            var nombreParameter = nombre != null ?
                new ObjectParameter("nombre", nombre) :
                new ObjectParameter("nombre", typeof(string));
    
            var codigoParameter = codigo != null ?
                new ObjectParameter("codigo", codigo) :
                new ObjectParameter("codigo", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_UpdateTipoCuenta", id_tipoCuentaParameter, nombreParameter, codigoParameter);
        }
    
        public virtual int sp_upgraddiagrams()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_upgraddiagrams");
        }
    
        public virtual ObjectResult<sp_ValidarSaldo_Result> sp_ValidarSaldo(Nullable<int> id_cuenta)
        {
            var id_cuentaParameter = id_cuenta.HasValue ?
                new ObjectParameter("id_cuenta", id_cuenta) :
                new ObjectParameter("id_cuenta", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_ValidarSaldo_Result>("sp_ValidarSaldo", id_cuentaParameter);
        }
    
        public virtual ObjectResult<sp_VerMovimiento_Result> sp_VerMovimiento(Nullable<int> numeroCuenta)
        {
            var numeroCuentaParameter = numeroCuenta.HasValue ?
                new ObjectParameter("numeroCuenta", numeroCuenta) :
                new ObjectParameter("numeroCuenta", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_VerMovimiento_Result>("sp_VerMovimiento", numeroCuentaParameter);
        }
    
        public virtual ObjectResult<sp_RetornaCliente_Result> sp_RetornaCliente(string primerApellido, string segundoApellido, string nombre, string correo)
        {
            var primerApellidoParameter = primerApellido != null ?
                new ObjectParameter("primerApellido", primerApellido) :
                new ObjectParameter("primerApellido", typeof(string));
    
            var segundoApellidoParameter = segundoApellido != null ?
                new ObjectParameter("segundoApellido", segundoApellido) :
                new ObjectParameter("segundoApellido", typeof(string));
    
            var nombreParameter = nombre != null ?
                new ObjectParameter("nombre", nombre) :
                new ObjectParameter("nombre", typeof(string));
    
            var correoParameter = correo != null ?
                new ObjectParameter("correo", correo) :
                new ObjectParameter("correo", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_RetornaCliente_Result>("sp_RetornaCliente", primerApellidoParameter, segundoApellidoParameter, nombreParameter, correoParameter);
        }
    
        public virtual ObjectResult<sp_RetornaTipoCliente_Result> sp_RetornaTipoCliente(string nombre, string descripcion)
        {
            var nombreParameter = nombre != null ?
                new ObjectParameter("nombre", nombre) :
                new ObjectParameter("nombre", typeof(string));
    
            var descripcionParameter = descripcion != null ?
                new ObjectParameter("descripcion", descripcion) :
                new ObjectParameter("descripcion", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_RetornaTipoCliente_Result>("sp_RetornaTipoCliente", nombreParameter, descripcionParameter);
        }
    }
}
