﻿using DAL.Interface.DTO;
using DAL.Interface.Repositories;
using ORM.Entities;
using System.Data.Entity;

namespace DAL.Reposirories
{
    public class ToDoItebRepository : Repository<ToDoItemDTO, ToDoItem>, IToDoItemRepository
    {
        public ToDoItebRepository(DbContext context) : base(context) { }
    }
}