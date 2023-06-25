SELECT
    columns.COLUMN_NAME as Name
     ,DATA_TYPE as DataType
     ,CHARACTER_MAXIMUM_LENGTH as StringLength
     ,(
    CASE
        WHEN IS_NULLABLE = 'NO' THEN 0
        ELSE 1
        END
    ) as IsNullable
     ,COLUMNPROPERTY(OBJECT_ID(columns.TABLE_SCHEMA + '.' + columns.TABLE_NAME), columns.COLUMN_NAME, 'IsIdentity') AS IsIdentity
     ,(
    CASE
        WHEN EXISTS (
            SELECT 1
            FROM INFORMATION_SCHEMA.KEY_COLUMN_USAGE
            WHERE OBJECTPROPERTY(OBJECT_ID(CONSTRAINT_SCHEMA + '.' + CONSTRAINT_NAME), 'IsPrimaryKey') = 1
              AND TABLE_SCHEMA = kcu.TABLE_SCHEMA
              AND TABLE_NAME = kcu.TABLE_NAME
              AND COLUMN_NAME = kcu.COLUMN_NAME
        )
            THEN 1
        ELSE 0
        END
    ) AS IsPrimaryKey
     ,COLUMN_DEFAULT as ColumnDefault
FROM
    INFORMATION_SCHEMA.COLUMNS AS columns
        LEFT JOIN INFORMATION_SCHEMA.KEY_COLUMN_USAGE kcu ON OBJECTPROPERTY(OBJECT_ID(CONSTRAINT_SCHEMA + '.' + CONSTRAINT_NAME), 'IsPrimaryKey') = 1
    AND columns.TABLE_SCHEMA = kcu.TABLE_SCHEMA
    AND columns.TABLE_NAME = kcu.TABLE_NAME
    AND columns.COLUMN_NAME = kcu.COLUMN_NAME
WHERE
        columns.TABLE_NAME = @TableName
ORDER BY
    columns.ORDINAL_POSITION
