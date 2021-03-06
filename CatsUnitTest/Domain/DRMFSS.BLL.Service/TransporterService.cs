﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DRMFSS.BLL.Services
{
    public class TransporterService : ITransporterService
    {
        private readonly IUnitOfWork _unitOfWork;

        public TransporterService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public bool AddTransporter(Transporter entity)
       {
           _unitOfWork.TransporterRepository.Add(entity);
           _unitOfWork.Save();
           return true;
           
       }
       public bool EditTransporter(Transporter entity)
       {
           _unitOfWork.TransporterRepository.Edit(entity);
           _unitOfWork.Save();
           return true;

       }
         public bool DeleteTransporter(Transporter entity)
        {
             if(entity==null) return false;
           _unitOfWork.TransporterRepository.Delete(entity);
           _unitOfWork.Save();
           return true;
        }
       public  bool DeleteById(int id)
       {
           var entity = _unitOfWork.TransporterRepository.FindById(id);
           if(entity==null) return false;
           _unitOfWork.TransporterRepository.Delete(entity);
           _unitOfWork.Save();
           return true;
       }
       public List<Transporter> GetAllTransporter()
       {
           return _unitOfWork.TransporterRepository.GetAll();
       } 
       public Transporter FindById(int id)
       {
           return _unitOfWork.TransporterRepository.FindById(id);
       }
       public List<Transporter> FindBy(Expression<Func<Transporter, bool>> predicate)
       {
           return _unitOfWork.TransporterRepository.FindBy(predicate);
       }
       
       
       public void Dispose()
       {
           _unitOfWork.Dispose();
           
       }

        public bool IsNameValid(int? TransporterID, string Name)
        {
             
       
           var Trans = _unitOfWork.TransporterRepository.FindBy(t=>t.Name == Name && t.TransporterID!=TransporterID).Any();
           if (Trans == null) return false;
           return true;

       
        }

       
    }
       
}




      
      