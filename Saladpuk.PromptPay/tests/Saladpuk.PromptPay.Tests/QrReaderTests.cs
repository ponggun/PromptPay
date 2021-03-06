﻿using Saladpuk.PromptPay.Facades;
using Saladpuk.PromptPay.Models;
using Xunit;

namespace Saladpuk.PromptPay.Tests
{
    public class QrReaderTests
    {
        private QrReader sut = new QrReader();

        [Fact]
        public void DefaultStaticCreditTransferQRMustBeReadable()
        {
            var qrCode = PPay.StaticQR.GetCreditTransferQR();
            var actual = sut.Read(qrCode);
            var expected = new QrInfo()
                .InitializeDefault()
                .SetPlanCreditTransfer();
            actual.ValidateWith(expected);
        }

        [Fact]
        public void DefaultDynamicCreditTransferQRMustBeReadable()
        {
            var qrCode = PPay.DynamicQR.GetCreditTransferQR();
            var actual = sut.Read(qrCode);
            var expected = new QrInfo()
                .InitializeDefault(staticQr: false)
                .SetPlanCreditTransfer();
            actual.ValidateWith(expected);
        }

        [Fact]
        public void DefaultStaticBillPaymentQRMustBeReadable()
        {
            var qrCode = PPay.StaticQR.GetBillPaymentQR();
            var actual = sut.Read(qrCode);
            var expected = new QrInfo()
                .InitializeDefault()
                .SetPlanBillPayment();
            actual.ValidateWith(expected);
        }

        [Fact]
        public void DefaultDynamicBillPaymentQRMustBeReadable()
        {
            var qrCode = PPay.DynamicQR.GetBillPaymentQR();
            var actual = sut.Read(qrCode);
            var expected = new QrInfo()
                .InitializeDefault(staticQr: false)
                .SetPlanBillPayment();
            actual.ValidateWith(expected);
        }
    }
}
