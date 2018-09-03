(function ($) {
    'use strict';

    var tabela = $("#datatable-repositorio-favorito").DataTable({
        destroy: true,
        processing: true,
        responsive: true,
        "paging": true,
        "deferRender": true,
        "searching": true,
        "info": true,
        serverSide: false,
        data: [],
        initComplete: function () {
            this.api().columns().every(function () {
                var column = this;
                var select = $('<select><option value=""></option></select>')
                    .appendTo($(column.footer()).empty())
                    .on('change', function () {
                        var val = $.fn.dataTable.util.escapeRegex(
                            $(this).val()
                        );

                        column
                            .search(val ? '^' + val + '$' : '', true, false)
                            .draw();
                    });

                column.data().unique().sort().each(function (d, j) {
                    select.append('<option value="' + d + '">' + d + '</option>')
                });
            });
        },
        columnDefs: [
            {
                "defaultContent": "-",
                "targets": "_all"
            },
            {
                targets: -1,
                data: 'ID',
                render: function (data, type, full) {
                    if (full.ID != null)
                        return '<a class="btn btn-warning btn-sm fa fa-star btn-lg excluir"  title="Desmarcar Favorito" id="btnExcluir" data-Id="' + full.ID + '" data-toggle="modal" data-target="#myModal" ></a> ';

                    return '';
                }
            },

            {
                targets: 0,
                data: 'ID',
                render: function (data, type, full) {
                    if (full.ID != null)
                        return full.ID

                    return '';
                }
            },
            {
                targets: 1,
                data: 'Login',
                render: function (data, type, full) {
                    if (full.Proprietario != null)
                        return full.Proprietario.login;

                    return ' ';
                }
            },
            {
                targets: 2,
                data: 'Name',
                render: function (data, type, full) {
                    if (full.Name != null)
                        return full.Name;

                    return '';
                }
            },
            {
                targets: 3,
                data: 'Description',
                render: function (data, type, full) {
                    if (full.Description != null)
                        return full.Description
                    return '';
                }
            },
            {
                targets: 4,
                data: 'Language',
                render: function (data, type, full) {
                    if (full.Language != null)
                        return full.Language
                    return '';
                }
            },
            {
                targets: 5,
                data: 'Updated_at',
                render: function (data, type, full) {
                    if (full.Updated_at !== null)
                        return moment(full.Updated_at).format('DD/MM/YYYY');

                    return "";
                }
            },            
        ],
        columns: [
            { data: 'ID', class: "centralizar-texto id" },
            {
                data: 'Login', class: "centralizar-texto"
            },
            {
                data: 'Name', class: "centralizar-texto"
            },
            {
                data: 'Description'
            },
            {
                data: 'Language', class: "centralizar-texto"
            },
            {
                data: 'Updated_at', class: "centralizar-texto"
            },            
            {
                data: 'ID', class: "centralizar-texto"
            }
        ],
    });

    function carregarTable() {
        $.ajax({
            url: baseUrl('Repositorio/PesquisarRepositoriosFavoritos'),
            type: "Get",
            dataType: "json",
            data: {},
            success: function (data) {
                if (data.length > 0) {
                    tabela.rows.add(data).draw(false);
                }
            },
            error: function (response) {
                alert(response.responseText);
            }
        });
    }
    carregarTable();

    tabela.columns().every(function () {
        var that = this;

        $('input', this.footer()).on('keyup change', function () {
            if (that.search() !== this.value) {
                that
                    .search(this.value)
                    .draw();
            }
        });
    });
    var item;
    var linha;
    $('#datatable-repositorio-favorito').delegate('#btnExcluir', 'click', function () {
        linha = $(this);
        item = linha.attr('data-Id');
    });

    $('#confirme').click(function () {
        $.ajax({
            url: baseUrl('Repositorio/ExcluirFavorito'),
            type: "GET",
            dataType: "json",
            data: {
                'Id': item
            },
            success: function (data) {
                if (data.Sucesso) {

                    $('#msg').after('<div class="alert alert-success"><a href="#" class="close" data-dismiss="alert" aria-label="close">&times;</a><strong>Sucesso!</strong> ' + data.mensagem + '</div>');
                    $(".alert-success")
                        .fadeTo(2000, 500)
                        .slideUp(500, function () {
                            $(this).remove();
                        });
                    removerLinhaItemTabela(linha);
                    $('#myModal').modal('toggle');
                }
            }
        });
    });

    function removerLinhaItemTabela(linha) {
        tabela.row(linha.parents('tr')).remove().draw(false);
    }


})($ || jquery);