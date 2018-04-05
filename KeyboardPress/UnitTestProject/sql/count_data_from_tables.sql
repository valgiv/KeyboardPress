
SELECT 'KP_SYSTEM_PARAMETERS' as table_name, COUNT(*) as [count] FROM KP_SYSTEM_PARAMETERS
union all SELECT 'KP_KEY_PRESS_COUNT' as table_name, COUNT(*) as [count] FROM KP_KEY_PRESS_COUNT
union all SELECT 'KP_WINDOWS' as table_name, COUNT(*) as [count] FROM KP_WINDOWS
union all SELECT 'KP_EVENT_KEY_CHAR' as table_name, COUNT(*) as [count] FROM KP_EVENT_KEY_CHAR
union all SELECT 'KP_EVENT_KEY_ALL' as table_name, COUNT(*) as [count] FROM KP_EVENT_KEY_ALL
union all SELECT 'KP_EVENT_MOUSE' as table_name, COUNT(*) as [count] FROM KP_EVENT_MOUSE
union all SELECT 'KP_MISTAKE_CHAR' as table_name, COUNT(*) as [count] FROM KP_MISTAKE_CHAR