﻿using PetHouse.Domain.Repositories;
using PetHouse.Persistence.Database;

namespace PetHouse.Persistence.Repositories
{
    public class RepositoryManager : IRepositoryManager
    {
        private readonly Lazy<IUnitOfWork> _lazyUnitOfWork;
        private readonly Lazy<IUsuarioRepositorio> _lazyUsuarioRepositorio;
        private readonly Lazy<IPetRepository> _lazyPetRepositorio;
        private readonly Lazy<IConsultaVeterinariaRepository> _lazyConsultaVeterinariaRepositorio;

        public RepositoryManager(PetHouseContext context)
        {
            _lazyUnitOfWork = new Lazy<IUnitOfWork>(() => new UnitOfWork(context));
            _lazyUsuarioRepositorio = new Lazy<IUsuarioRepositorio>(() => new UsuarioRepository(context));
            _lazyPetRepositorio = new Lazy<IPetRepository>(() => new PetRepository(context));
            _lazyConsultaVeterinariaRepositorio = new Lazy<IConsultaVeterinariaRepository>(() => new ConsultaVeterinariaRepository(context));

        }

        public IUnitOfWork UnitOfWork => _lazyUnitOfWork.Value;
        public IUsuarioRepositorio UsuarioRepositorio => _lazyUsuarioRepositorio.Value;
        public IPetRepository PetRepositorio => _lazyPetRepositorio.Value;
        public IConsultaVeterinariaRepository ConsultaVeterinariaRepository => _lazyConsultaVeterinariaRepositorio.Value;
    }
}
