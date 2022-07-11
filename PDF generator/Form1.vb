
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
        Dim PDFc As New Document()
        PdfWriter.GetInstance(PDFc, New FileStream("C:\Users\User\source\repos\PDF generator\resume.pdf", FileMode.Create))

        Dim main_font As iTextSharp.text.Font = FontFactory.GetFont(iTextSharp.text.Font.FontFamily.TIMES_ROMAN.ToString(), 22, iTextSharp.text.Font.BOLD)
        Dim lessmain_font As iTextSharp.text.Font = FontFactory.GetFont(iTextSharp.text.Font.FontFamily.TIMES_ROMAN.ToString(), 17, iTextSharp.text.Font.BOLD)
        Dim second_font As iTextSharp.text.Font = FontFactory.GetFont(iTextSharp.text.Font.FontFamily.TIMES_ROMAN.ToString(), 15, iTextSharp.text.Font.BOLD)
        Dim normal_font As iTextSharp.text.Font = FontFactory.GetFont(iTextSharp.text.Font.FontFamily.TIMES_ROMAN.ToString(), 12, iTextSharp.text.Font.NORMAL)
        Dim smaller_font As iTextSharp.text.Font = FontFactory.GetFont(iTextSharp.text.Font.FontFamily.TIMES_ROMAN.ToString(), 10, iTextSharp.text.Font.NORMAL)
        Dim space_font As iTextSharp.text.Font = FontFactory.GetFont(iTextSharp.text.Font.FontFamily.TIMES_ROMAN.ToString(), 5, iTextSharp.text.Font.NORMAL)
        Dim normal_bold As iTextSharp.text.Font = FontFactory.GetFont(iTextSharp.text.Font.FontFamily.TIMES_ROMAN.ToString(), 12, iTextSharp.text.Font.ITALIC)
        Dim separate As New LineSeparator(2.0F, 100.0F, BaseColor.BLACK, Element.ALIGN_BOTTOM, 1)
        Dim sName As New Paragraph(yourjson.FullName & vbLf, main_font)
        Dim Profile As New Paragraph(vbLf & yourjson.Profile & vbLf & vbLf, normal_font)
        Dim Address As New Paragraph(vbLf & yourjson.Address & vbLf)
        Dim Num As New Paragraph(vbLf & yourjson.PhoneNumber & vbLf)
        Dim Email As New Paragraph(yourjson.Email & vbLf & vbLf & vbLf)
        Dim About As New Paragraph(yourjson.About & vbLf, lessmain_font)
        Dim Educ As New Paragraph(yourjson.Educ.ToString(), lessmain_font)
        Dim College As New Paragraph(vbLf & yourjson.College.ToString(), second_font)
        Dim School As New Paragraph(yourjson.School.ToString(), smaller_font)
        Dim Year As New Paragraph(yourjson.Year.ToString(), normal_bold)
        Dim space As New Paragraph(vbLf, space_font)


        PDFc.Open()
        PDFc.Add(sName)
        PDFc.Add(space)
        PDFc.Add(separate)
        PDFc.Add(separate)
        PDFc.Add(Address)
        PDFc.Add(Num)
        PDFc.Add(Email)
        PDFc.Add(About)
        PDFc.Add(Profile)
        PDFc.Add(space)
        PDFc.Add(space)
        PDFc.Add(separate)
        PDFc.Add(Educ)
        PDFc.Add(College)
        PDFc.Add(School)
        PDFc.Add(Year)

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
