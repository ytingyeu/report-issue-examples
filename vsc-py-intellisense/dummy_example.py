class ClassA(object):
    def __init__(self):
        self._name = "Class A"

    def get_name(self):
        return self._name


class ClassB(object):
    def __init__(self):
        self._name = "Class B"

    def get_name(self):
        return self._name


class ClientsFactory(object):
    def __init__(self, root):
        self._root = root

    def get_class_a(self):
        return self._root._get_client('class.a')

    def get_class_b(self):
        return self._root._get_client('class.b')


class ClassRoot(object):
    def __init__(self):
        self.clients = ClientsFactory(self)
        self._cache = {}

    def _get_client(self, client_type):
        if client_type not in self._cache:
            self._cache[client_type] = self._get_instance(client_type)
        return self._cache[client_type]

    def _get_instance(self, client_class):
        if client_class == "class.a":
            return ClassA()

        if client_class == "class.b":
            return ClassB()


root = ClassRoot()
a = root.clients.get_class_a()

# Not able to list function get_name() with variable a
# but the function does work
print(a.get_name())
