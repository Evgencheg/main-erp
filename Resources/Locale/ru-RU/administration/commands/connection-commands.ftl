## Strings for the "grant_connect_bypass" command.

cmd-grant_connect_bypass-desc = Временно разрешает пользователю обойти обычные проверки подключения.
cmd-grant_connect_bypass-help =
    Использование: grant_connect_bypass <пользователь> [длительность в минутах]
    Временно предоставляет пользователю возможность обойти обычные ограничения подключения.
    Обход применяется только к этому игровому серверу и истекает через (по умолчанию) 1 час.
    Они смогут присоединиться независимо от белого списка, панического бункера или лимита игроков.
cmd-grant_connect_bypass-arg-user = <пользователь>
cmd-grant_connect_bypass-arg-duration = [длительность в минутах]
cmd-grant_connect_bypass-invalid-args = Ожидается 1 или 2 аргумента
cmd-grant_connect_bypass-unknown-user = Не удалось найти пользователя «{ $user }»
cmd-grant_connect_bypass-invalid-duration = Неверная длительность «{ $duration }»
cmd-grant_connect_bypass-success = Обход успешно добавлен для пользователя «{ $user }»
