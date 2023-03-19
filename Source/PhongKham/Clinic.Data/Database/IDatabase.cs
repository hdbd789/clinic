﻿using System;
using System.Collections.Generic;
using System.Data;
using Clinic.Data.Models;

namespace Clinic.Data.Database
{
    public interface IDatabase
    {
        IDataReader ExecuteReader(string StoreProcName, List<IDataParameter> Params);
        DataTable ExecuteReaderAdapter(string StoreProcName, List<IDataParameter> Params);
        void CreateDatabase(string password);
        int InsertRowToTable(string nameOfTable, List<string> nameOfColumns, List<string> values);
        int ExecuteNonQuery(string StoreProcName, List<IDataParameter> Params);

        object ExecuteScalar(string query);
        void CloseCurrentConnection();

        List<LoaiKham> GetAllLoaiKham();
        List<ReasonApointmentModel> GetListReason();
        void DeleteRowInTableByID(string nameTable, string nameID, string ID);
        void UpdateRowToTable(string nameOfTable, List<string> nameOfColumns,
            List<string> values, string namecolumn, string id);
        void UpdateRowToTable(string nameOfTable, List<string> nameOfColumns,
            List<string> values, string nameColumn, string id, string visitDate);
        void UpdateRowToTableCalendar(string nameOfTable, List<string> nameOfColumns,
            List<string> values, string id, string Username);
        void DeleteRowToTableCalendar(string nameOfTable, string id, string Username);
        void DeleteRowFromTablelistpatienttoday(string id, string name);
        List<ADate> GetAllDateOfUser(string Username);
        int GetCountFromMecidicByName(string name);
        string SearchIDHistoryByIDPatientAndDay(string idPatient, string visitDate);
        bool CheckMedicineExists(string Id);
        string GetNameOfDoctor(string name);
        List<PatientToday> GetListPatientToday();
        List<string> GetAllDiagnosesFromHistory(DateTime date);
        string GetNamePatientByID(string id);
        Medicine GetMedicineFromName(string name);

        List<InfoPatient> GetAllPatientInfo(DateTime fromDate, DateTime toDate);

        List<InfoPatient> LoadDataFromHistory(string query);
        List<InfoPatient> LoadDataFromAdvisory(string query);
    }
}
