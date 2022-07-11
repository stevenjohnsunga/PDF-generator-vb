
Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Linq
Imports System.Text
Imports System.Threading.Tasks
Imports System.Windows.Forms
Imports Newtonsoft.Json
Imports iTextSharp.text
Imports iTextSharp.text.pdf
Imports iTextSharp.text.pdf.draw
Imports System.IO
Public Class Form1
    Public location As String = "C:\Users\User\source\repos\PDF generator\resume.json"
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim steven As String = File.ReadAllText(location)
        Dim yourjson As myjson = JsonConvert.DeserializeObject(Of myjson)(steven)
        Dim xpdf As New Document()
        PdfWriter.GetInstance(xpdf, New FileStream("C:\Users\User\source\repos\PDF generator\resume.json", FileMode.Create))

        Dim mainfont As iTextSharp.text.Font = FontFactory.GetFont(iTextSharp.text.Font.FontFamily.TIMES_ROMAN.ToString(), 22, iTextSharp.text.Font.BOLD)
        Dim lessmainfont As iTextSharp.text.Font = FontFactory.GetFont(iTextSharp.text.Font.FontFamily.TIMES_ROMAN.ToString(), 17, iTextSharp.text.Font.BOLD)
        Dim secondfont As iTextSharp.text.Font = FontFactory.GetFont(iTextSharp.text.Font.FontFamily.TIMES_ROMAN.ToString(), 15, iTextSharp.text.Font.BOLD)
        Dim normalfont As iTextSharp.text.Font = FontFactory.GetFont(iTextSharp.text.Font.FontFamily.TIMES_ROMAN.ToString(), 12, iTextSharp.text.Font.NORMAL)
        Dim smallerfont As iTextSharp.text.Font = FontFactory.GetFont(iTextSharp.text.Font.FontFamily.TIMES_ROMAN.ToString(), 10, iTextSharp.text.Font.NORMAL)
        Dim spacefont As iTextSharp.text.Font = FontFactory.GetFont(iTextSharp.text.Font.FontFamily.TIMES_ROMAN.ToString(), 5, iTextSharp.text.Font.NORMAL)
        Dim normalbold As iTextSharp.text.Font = FontFactory.GetFont(iTextSharp.text.Font.FontFamily.TIMES_ROMAN.ToString(), 12, iTextSharp.text.Font.ITALIC)
        Dim separate As New LineSeparator(2.0F, 100.0F, BaseColor.BLACK, Element.ALIGN_BOTTOM, 1)
        Dim sName As New Paragraph(yourjson.FullName & vbLf, mainfont)
        Dim Profile As New Paragraph(vbLf & yourjson.Profile & vbLf & vbLf, normalfont)
        Dim Address As New Paragraph(vbLf & yourjson.Address & vbLf)
        Dim Num As New Paragraph(vbLf & yourjson.PhoneNumber & vbLf)
        Dim Email As New Paragraph(yourjson.Email & vbLf & vbLf & vbLf)
        Dim About As New Paragraph(yourjson.About & vbLf, lessmainfont)
        Dim Educ As New Paragraph(yourjson.Educ.ToString(), lessmainfont)
        Dim College As New Paragraph(vbLf & yourjson.College.ToString(), secondfont)
        Dim School As New Paragraph(yourjson.School.ToString(), smallerfont)
        Dim Year As New Paragraph(yourjson.Year.ToString(), normalbold)
        Dim space As New Paragraph(vbLf, spacefont)


        xpdf.Open()
        xpdf.Add(sName)
        xpdf.Add(space)
        xpdf.Add(separate)
        xpdf.Add(separate)
        xpdf.Add(Address)
        xpdf.Add(Num)
        xpdf.Add(Email)
        xpdf.Add(About)
        xpdf.Add(Profile)
        xpdf.Add(space)
        xpdf.Add(space)
        xpdf.Add(separate)
        xpdf.Add(Educ)
        xpdf.Add(College)
        xpdf.Add(School)
        xpdf.Add(Year)

        MessageBox.Show("PDF has been generated!")
    End Sub

    Public Class myjson
        Public Property FullName As String
        Public Property Profile As String
        Public Property Address As String
        Public Property PhoneNumber As String
        Public Property Email As String
        Public Property About As String
        Public Property Educ As String
        Public Property College As String
        Public Property School As String
        Public Property Year As String

    End Class

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class
