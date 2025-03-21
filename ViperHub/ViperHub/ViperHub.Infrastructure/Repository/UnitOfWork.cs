using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViperHub.Domain.Models;

namespace ViperHub.Infrastructure.Repository
{
    
    public class UnitOfWork : IUnitOfWork
    {
        public UnitOfWork(CategoriaForoRepository CategoriaForos, ClaneRepository Clanes, ComentarioForoRepository ComentarioForos, EquiposTorneoRepository EquipoTorneos, MultimediumRepository Multimedias, TemasForoRepository TemasForos, TorneoRepository Tournaments, UsuarioClaneRepository UsersClan, UsuarioRepository User)
        {
            CategoriaForo = CategoriaForos;
            Clan = Clanes;
            ComentarioForo = ComentarioForos;
            EquiposTorneos = EquipoTorneos;
            Multimedia = Multimedias;
            TemasForo = TemasForos;
            Torneos = Tournaments;
            Usuarios = User;
            UsuarioClanes = UsersClan;

        }

        CategoriaForoRepository CategoriaForo { get; }    
        ClaneRepository Clan { get; }
        ComentarioForoRepository ComentarioForo { get; }
        EquiposTorneoRepository EquiposTorneos { get; }
        MultimediumRepository Multimedia { get; }
        TemasForoRepository TemasForo { get; }
        TorneoRepository Torneos { get; }
        UsuarioRepository Usuarios { get; }
        UsuarioClaneRepository UsuarioClanes { get; }
     
    }
}
