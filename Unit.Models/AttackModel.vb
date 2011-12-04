Imports System.Collections
Imports System.ComponentModel

Imports Core.Model
Imports Unit.Core

Public Class AttackModel
    Inherits ModelBase

    Private Attack As IAttack

    Public ReadOnly Property AttackType As AttackTypes
        Get
            Return Attack.AttackType
        End Get
    End Property

    Public Sub New(_attack As IAttack)
        Attack = _attack
    End Sub
End Class