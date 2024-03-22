using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace SciFiSim.HTMLTemplates
{
    public class TestReact
    {
        public static string GetHtml()
        {
            return @"<html>
                <head>
                    <title>React Grid Example</title>
                    <script src='https://unpkg.com/react@16/umd/react.development.js'></script>
                    <script src='https://unpkg.com/react-dom@16/umd/react-dom.development.js'></script>
                    <script src='https://unpkg.com/babel-standalone@^6.26.0/babel.min.js'></script>
                </head>
                <body>
                    <div id='root'></div>
                    <script type='text/babel'>
                        class GridComponent extends React.Component {
                            constructor(props) {
                                super(props);
                                this.state = {
                                    rowData: [
                                        { make: 'Toyota', model: 'Celica', price: 35000 },
                                        { make: 'Ford', model: 'Mondeo', price: 32000 },
                                        { make: 'Porsche', model: 'Boxster', price: 72000 }
                                    ]
                                };
                            }

                            render() {
                                return (
                                    <div className='ag-theme-alpine' style={{ height: '200px', width: '600px' }}>
                                        <ag-grid-react
                                            style={{ width: '100%', height: '100%' }}
                                            rowData={this.state.rowData}
                                            columnDefs={[
                                                { headerName: 'Make', field: 'make' },
                                                { headerName: 'Model', field: 'model' },
                                                { headerName: 'Price', field: 'price' }
                                            ]}
                                        ></ag-grid-react>
                                    </div>
                                );
                            }
                        }

                        ReactDOM.render(
                            <GridComponent />,
                            document.getElementById('root')
                        );
                    </script>
                </body>
                </html>";
        }
    }
}
