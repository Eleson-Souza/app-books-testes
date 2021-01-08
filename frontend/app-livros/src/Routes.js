import { Route, Switch } from 'react-router-dom';

import RegisterBook from './pages/RegisterBook';
import UpdatedBook from './pages/UpdatedBook';

function Routes() {
    return (
        <Switch>
            <Route path="/book/register">
                <RegisterBook />
            </Route>
            <Route path="/book/update">
                <UpdatedBook />
            </Route>
            <Route path="/book/delete">

            </Route>
            <Route path="/book/list">

            </Route>
        </Switch>
    );
}

export default Routes;

