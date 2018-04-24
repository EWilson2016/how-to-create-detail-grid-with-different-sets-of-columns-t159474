Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports System.Threading.Tasks

Namespace DetailDescriptorExample
    Public Class TaskViewModel
        Private _TaskData As List(Of ParentTaskData)

        Public ReadOnly Property TaskData() As List(Of ParentTaskData)
            Get
                If _TaskData Is Nothing Then
                    _TaskData = New List(Of ParentTaskData)()
                    For i As Integer = 0 To 9
                        Dim parentData As New ParentTaskData() With { _
                            .TaskGroup = "TaskGroup " & i, _
                            .Number = i, _
                            .List = New List(Of Object)() _
                        }
                        If i Mod 2 = 0 Then
                            For j As Integer = 0 To 4
                                parentData.List.Add(New Task() With { _
                                    .Name = "Task " & j, _
                                    .Number = j, _
                                    .Ready = j Mod 2 <> 0 _
                                })
                            Next j
                        Else
                            For j As Integer = 0 To 4
                                parentData.List.Add(New MultipleTask() With { _
                                    .SubNameOne = "Sub Task " & j, _
                                    .SubNameTwo = "Sub Task " & (j + 1), _
                                    .SubNumber = j, _
                                    .MultipleReady = j Mod 2 <> 0 _
                                })
                            Next j
                        End If

                        _TaskData.Add(parentData)
                    Next i
                End If
                Return _TaskData
            End Get
        End Property
    End Class

    Public Class Task
        Public Property Name() As String
        Public Property Number() As Integer
        Public Property Ready() As Boolean
    End Class

    Public Class MultipleTask
        Public Property SubNameOne() As String
        Public Property SubNameTwo() As String
        Public Property SubNumber() As Integer
        Public Property MultipleReady() As Boolean
    End Class

    Public Class ParentTaskData
        Public Property TaskGroup() As String
        Public Property Number() As Integer
        Public Property List() As List(Of Object)
    End Class
End Namespace
