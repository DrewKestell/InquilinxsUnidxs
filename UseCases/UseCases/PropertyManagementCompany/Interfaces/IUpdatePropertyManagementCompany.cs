﻿using DataAccess.FormObject;

namespace UseCases
{
    public interface IUpdatePropertyManagementCompany
    {
        void Execute(PropertyManagementCompanyFormObject formObject, int userID);
    }
}