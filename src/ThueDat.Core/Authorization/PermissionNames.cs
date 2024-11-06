using Abp.MultiTenancy;
using System.Collections.Generic;

namespace ThueDat.Authorization
{
    public static class PermissionNames
    {
        public const string TabAdmin = "Admin";        
        public const string Pages_Tenants = "Pages.Tenants";
        public const string Pages_Users = "Pages.Users";
        public const string Pages_Users_Activation = "Pages.Users.Activation";
        public const string Pages_Roles = "Pages.Roles";

        public const string TabQuanLy = "QuanLy";
        public const string Pages_NguoiNopThue = "Pages.NguoiNopThue";
        public const string Pages_QuyetDinhChoThueDat = "Pages.QuyetDinhChoThueDat";
        public const string Pages_ThuaDat = "Pages.ThuaDat";

        public const string TabThongBao = "ThongBao";
        public const string Pages_ThongBaoDonGiaThueDat = "Pages.ThongBaoDonGiaThueDat";
        public const string Pages_ThongBaoThuHangNam = "Pages.ThongBaoThuHangNam";

    }

    public class SystemPermission
    {
        public string Name { get; set; }
        public string DisplayName { get; set; }

        public static List<SystemPermission> ListPermissions = new List<SystemPermission>()
        {
            #region Tab Admin
            new SystemPermission{ Name = PermissionNames.TabAdmin ,DisplayName = "Tab Admin"},
            new SystemPermission{ Name = PermissionNames.Pages_Users ,DisplayName = "Page User"},
            new SystemPermission{ Name = PermissionNames.Pages_Users_Activation ,DisplayName = "Page Users Activation"},
            new SystemPermission{ Name = PermissionNames.Pages_Roles ,DisplayName = "Page Role"},
            #endregion
            new SystemPermission{ Name = PermissionNames.TabQuanLy ,DisplayName = "Tab QuanLy"},
            new SystemPermission{ Name = PermissionNames.Pages_NguoiNopThue ,DisplayName = "Page NguoiNopThue"},
            new SystemPermission{ Name = PermissionNames.Pages_QuyetDinhChoThueDat ,DisplayName = "Page QuyetDinhChoThueDat"},
            new SystemPermission{ Name = PermissionNames.Pages_ThuaDat ,DisplayName = "Page ThuaDat"},

            new SystemPermission{ Name = PermissionNames.TabThongBao ,DisplayName = "Tab ThongBao"},
            new SystemPermission{ Name = PermissionNames.Pages_ThongBaoDonGiaThueDat ,DisplayName = "Page ThongBaoDonGiaThueDat"},
            new SystemPermission{ Name = PermissionNames.Pages_ThongBaoThuHangNam ,DisplayName = "Page ThongBaoThuHangNam"},

        };
     }   
}

