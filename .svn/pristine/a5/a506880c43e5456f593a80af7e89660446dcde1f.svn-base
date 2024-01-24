using System;
using System.IO;
using NUnit.Framework;

namespace Com.Suncor.Olt.Common.Extension
{
    [TestFixture]
    public class DirectoryInfoExtensionsTest
    {
        [Test]
        public void ShouldBeAUncPath()
        {
            Assert.That(new DirectoryInfo(@"\\file015\Cornerstone").IsUncDrive(), Is.True);
        }

        [Test]
        public void ShouldNotBeAUncPathWithUriFormat()
        {
            Assert.Throws(typeof(ArgumentException), () => new DirectoryInfo(@"file://file015/Cornerstone").IsUncDrive());
        }

        [Test]
        public void ShouldNotBeAUncPathWithUriFormatAndFileName()
        {
            Assert.Throws(typeof(ArgumentException), () => new DirectoryInfo(@"file://file015/Cornerstone").IsUncDrive());
        }

        [Test]
        public void ShouldBeAUncPathWithDriveLetter()
        {
            Assert.That(new DirectoryInfo(@"\\d71672\C$\Documents And Settings").IsUncDrive(), Is.True);
        }

        [Test]
        public void ShouldNotBeAUncPathWithFileName()
        {
            Assert.That(new DirectoryInfo(@"\\file015\Cornerstone\file.txt").IsUncDrive(), Is.False);
        }

        [Test]
        public void ShouldNotBeAValidUncPathIfItIsTooLong()
        {
            string reallyLongPath = @"\\file015\Cornerstone\".PadRight(260, 'Z');
            Assert.Throws(typeof (PathTooLongException), () => new DirectoryInfo(reallyLongPath));
        }
    }
}