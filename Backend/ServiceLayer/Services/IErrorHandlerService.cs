﻿namespace ServiceLayer.Services
{
    public interface IErrorHandlerService
    {
        int GetErrorOcurrenceCount();
        void IncrementErrorOccurrenceCount(string errorMessage);
        void ContactSystemAdmin(string errorMessage);
        bool IsErrorCounterAtMax();
    }
}