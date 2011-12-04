Public Class StrafeAttack
    Implements IAttack

    Public ReadOnly Property AttackType As AttackTypes Implements IAttack.AttackType
        Get
            Return AttackTypes.Strafe
        End Get
    End Property

    Public Property AttackValue As IAttackValue Implements IAttack.AttackValue
End Class
