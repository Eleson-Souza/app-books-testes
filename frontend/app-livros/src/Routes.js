import { Route, Switch } from 'react-router-dom';

import RegisterBook from './pages/RegisterBook';
import UpdatedBook from './pages/UpdatedBook';
import DeleteBook from './pages/DeleteBook';
import ListBook from './pages/ListBooks';

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
                <DeleteBook />
            </Route>
            <Route path="/book/list">
                <ListBook />
            </Route>
        </Switch>
    );
}

export default Routes;

