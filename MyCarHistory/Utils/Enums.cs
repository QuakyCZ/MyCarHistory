using System;
using System.Collections.Generic;
using System.Text;

namespace MyCarHistory.Utils {
    public enum ServiceType {
        Repair,
        TechnicalInspection,
        STK
    }

    public static class ServiceTypeEnum {
        public static string ToString(ServiceType type) {
            switch (type) {
                case ServiceType.Repair:
                    return "Oprava";
                case ServiceType.TechnicalInspection:
                    return "Technická kontrola";
                case ServiceType.STK:
                    return "STK";
                default:
                    return "N/A";
            }
        }
    }
}
